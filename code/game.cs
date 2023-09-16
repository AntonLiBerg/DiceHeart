using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class game : Control
{
	private Node _selectedDie;
	private PlayerState _playerState;
	private double _sinceLastInput = 0;
	public override void _Ready()
	{
		InitSignals();
		GetNode<Label>("ResGold/Label").Text = "10";
		GetNode<Label>("ResGold/Label").Text = "10";
		_playerState = PlayerState.None;
	}
	private void InitSignals()
	{
		var buttonPlay = GetNode<Button>("Button");
		var buttonRoll = GetNode<Button>("Dicetray/ButtonRoll");
		var buttonAdd = GetNode<Button>("Dicetray/ButtonAdd");
		var Cards = GetTree().GetNodesInGroup("CardWithDice");

		buttonRoll.Pressed += _on_button_roll_pressed;
		buttonAdd.Pressed += _on_button_add_pressed;
		buttonPlay.Pressed += _on_button_play_pressed;

		foreach (CardWithDice c in Cards)
		{
			c.AddDieToCard += _on_card_adddie_pressed;
		}

	}

	public override void _Process(double delta)
	{
		_sinceLastInput += delta;
		if (!Input.IsAnythingPressed() ||
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
				if (_playerState == PlayerState.DieSelected)
				{
					var dVal = LogicDice.GetDieValue(_selectedDie);
					DeselectDie();
					if (dVal == i)
						return;
				}

				_selectedDie = LogicDiceTray.TrySelectDie(i, this);
				if (_selectedDie is null)
					return;

				_playerState = PlayerState.DieSelected;
				ShowAddDieButtons(true);
			}
		}
	}

	private void _on_button_roll_pressed()
	{
		if (!TryPay(1))
			return;
		var dList = GetNode<Node>("Dicetray/GridContainer");
		foreach (Control item in dList.GetChildren())
		{
			LogicDice.RollDie(item);
		}
	}
	private void _on_button_add_pressed()
	{
		if (!TryPay(2))
			return;
		LogicDiceTray.AddDie(this);
	}
	private void _on_card_adddie_pressed(Button emitter)
	{
		_selectedDie
			.GetParent()
			.RemoveChild(_selectedDie);
		emitter
			.GetParent()
			.GetNode("GridContainer")
			.AddChild(_selectedDie);
		emitter
			.GetParent()
			.GetNode<Button>("Button")
			.Visible = false;

		ShowAddDieButtons(false);
		DeselectDie();
	}
	private void DeselectDie()
	{
		LogicDice.ToggleDieColorSelected(_selectedDie);
		_playerState = PlayerState.None;
		_selectedDie = null;
	}
	private void ShowAddDieButtons(bool isVisible)
	{
		foreach (var n in GetTree().GetNodesInGroup("Cards"))
		{
			if (!LogicCard.IsRoomForDice(n))
				continue;

			n.GetNode<Button>("CardWithDice/Button")
				.Visible = isVisible;
		}
	}
	private bool TryPay(int cost)
	{
		var amountNode = GetNode<Label>("ResGold/Label");
		if (amountNode.Text.ToInt() < cost)
			return false;

		amountNode.Text = (amountNode.Text.ToInt() - cost).ToString();
		return true;
	}


	private void _on_button_play_pressed()
	{
		//1. Alla kort effekter
		foreach (Node n in GetTree().GetNodesInGroup("Cards"))
		{
			LogicCard.CallUpdateGame(n, this);
		}
		//2. Alla resurs-effekter
		//3. Alla event-effekter
	}
}
