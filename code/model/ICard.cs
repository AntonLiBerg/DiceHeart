using System.Collections.Generic;
using System.Linq;
using Godot;

public abstract class ICard
{
    public Card Card { get; protected set; }
    public abstract string Title { get; protected set; }
    public abstract string Description { get; protected set; }
    public abstract Color BColor { get; protected set; }
    public virtual bool ShowProgress { get; protected set; } = false;
    public int Progress { get; protected set; } = 0;

    public abstract bool DieMeetsReq(Die d);
    public virtual bool IsRoomForDie()
		=> GetDice().Count < 8;
    public abstract void UpdateGame(Root root);
    public void ShowButton() 
        => Card.GetNode<Button>("Button")
            .Visible = true;
    public void HideButton() 
        => Card.GetNode<Button>("Button")
            .Visible = false;
    public List<Node> GetDice()
    {
        return Card.GetNode("GridContainer")
            .GetChildren()
            .ToList();
    }
    public void RemoveAllDice()
        => GetDice()
            .ForEach(d => d.QueueFree());
    public void Make(Root root)
    {
        Card = (Card)((PackedScene)GD.Load("res://stuff/Card.tscn"))
            .Instantiate();
        Card.GetNode<Label>("Label").Text = Title;
        Card.GetNode<Label>("Label2").Text = Description;
        if (ShowProgress)
        {
            Card.GetNode<Label>("Label3").Visible = true;
            Card.GetNode<Label>("Label4").Visible = true;

            Card.GetNode<Label>("Label3").Text = "Progress:";
            Card.GetNode<Label>("Label4").Text = "0";
        }
        Card.GetNode<ColorRect>("ColorRect").Color = BColor;
        root.GetNode<GridContainer>("Cards")
            .AddChild(Card);
            
        Card.GetNode<Button>("Button")
            .Pressed += () =>
            {
                root.SelectedDie
                    .GetParent()
                    .RemoveChild(root.SelectedDie);
                Card.GetNode<GridContainer>("GridContainer")
                    .AddChild(root.SelectedDie);
                root.HideAddDieButtons();
                root.DeselectDie();
            };
    }
}