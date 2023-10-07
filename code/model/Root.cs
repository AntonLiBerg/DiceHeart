using System;
using System.Collections.Generic;
using System.ComponentModel;
using Godot;

public class Root
{
    public Die SelectedDie;
    public PlayerState PlayerState;
    public double _sinceLastInput = 0;
    public Control Game { get; private set; }
    public List<ICard> Cards;
    public List<IChange> Changes;
    public Root(Control game)
    {
        Game = game;
        var buttonPlay = GetNode<Button>("Button");
        var buttonRoll = GetNode<Button>("Dicetray/ButtonRoll");
        var buttonAdd = GetNode<Button>("Dicetray/ButtonAdd");
        PlayerState = PlayerState.Start;
        Cards = new List<ICard>();
        Changes = new List<IChange>();

        buttonRoll.Pressed += _on_button_roll_pressed;
        buttonAdd.Pressed += _on_button_add_pressed;
        buttonPlay.Pressed += _on_button_play_pressed;
    }

    public void Process(double delta)
    {
        if (PlayerState == PlayerState.Start)
        {
            var ch = new CrdHeart();
            ch.Make(this);
            Cards.Add(ch);
            var ci = new CrdInvest();
            ci.Make(this);
            Cards.Add(ci);

            PlayerState = PlayerState.None;
            var c = new BnIncomeTax();
            c.MakeChange(this);
            Changes.Add(c);
        }
        else if (PlayerState == PlayerState.GameOverStart)
        {
            ShowGameOver();
            PlayerState = PlayerState.GameOver;
        }

        _sinceLastInput += delta;
        if (PlayerState == PlayerState.GameOver ||
                !Input.IsAnythingPressed() ||
                _sinceLastInput < 0.1 ||
                Input.IsMouseButtonPressed(MouseButton.Left) ||
                Input.IsMouseButtonPressed(MouseButton.Right) ||
                Input.IsMouseButtonPressed(MouseButton.Middle)
            )
            return;


        _sinceLastInput = 0;
        var keys = new Key[] { Key.Key0, Key.Key1, Key.Key2, Key.Key3, Key.Key4, Key.Key5, Key.Key6 };
        for (int i = 1; i < 7; i++)
        {
            var k = keys[i];
            if (Input.IsKeyPressed(k))
            {
                if (PlayerState == PlayerState.DieSelected)
                {
                    var dVal = LogicDice.GetDieValue(SelectedDie);
                    DeselectDie();
                    if (dVal == i)
                        return;
                }

                SelectedDie = LogicDiceTray.TrySelectDie(i, this);
                if (SelectedDie is null)
                    return;

                PlayerState = PlayerState.DieSelected;
                ShowAddDieButtons();
            }
        }
    }

    public void ShowGameOver()
    {
        var n = GetNode<Control>("PopGameOver");
        n.Visible = true;
        n.GetNode<Button>("Button").Pressed += () =>
        {
            GetTree().ReloadCurrentScene();
        };
    }

    public T GetNode<T>(string path) where T : Control
        => Game.GetNode<T>(path);
    public SceneTree GetTree()
        => Game.GetTree();
    public void DeselectDie()
    {
        LogicDice.ToggleDieColorSelected(SelectedDie);
        PlayerState = PlayerState.None;
        SelectedDie = null;
        HideAddDieButtons();
    }
    public void ShowAddDieButtons()
    {
        foreach (ICard c in Cards)
        {
            if (!c.IsRoomForDie()
                || !c.DieMeetsReq(SelectedDie))
                continue;

            c.ShowButton();
        }
    }
    public void HideAddDieButtons()
    {
        foreach (var c in Cards)
            c.HideButton();
    }
    public bool TryPay(int cost)
    {
        var amountNode = GetNode<Label>("ResGold/Label");
        if (amountNode.Text.ToInt() < cost)
            return false;

        amountNode.Text = (amountNode.Text.ToInt() - cost).ToString();
        return true;
    }
    public void AddNewChange(IChange c)
    {
        Changes.Add(c);
        c.MakeChange(this);
    }

    //EVENTS
    public void _on_button_roll_pressed()
    {
        if (!TryPay(1))
            return;
        var dList = GetNode<Control>("Dicetray/GridContainer");
        foreach (Die item in dList.GetChildren())
            LogicDice.RollDie(item);
    }
    public void _on_button_add_pressed()
    {
        if (!TryPay(2))
            return;
        LogicDiceTray.AddDie(this);
    }
    public void _on_card_adddie_pressed(Button emitter)
    {
        SelectedDie
            .GetParent()
            .RemoveChild(SelectedDie);
        emitter
            .GetParent()
            .GetNode("GridContainer")
            .AddChild(SelectedDie);
        emitter
            .GetParent()
            .GetNode<Button>("Button")
            .Visible = false;

        HideAddDieButtons();
        DeselectDie();
    }
    public void _on_button_play_pressed()
    {
        foreach (ICard c in Cards)
            c.UpdateGame(this);


        //2. Alla event effekter
        foreach (IChange c in Changes)
            c.UpdateGame(this);

        //Upkeep och turn
        var h = GetNode<Label>("ResHeart/Label").Text.ToInt();
        h--;
        GetNode<Label>("ResHeart/Label").Text = h.ToString();
        var t = GetNode<Label>("Label2").Text.ToInt();
        t++;
        GetNode<Label>("Label2").Text = t.ToString();
        
        var r = new Random().Next(1, 6);
        if (r == 1)
            AddNewChange(new AlPoorHarvest());
        else if (r == 2)
            AddNewChange(new AlCrimeWave());
    }
}
