using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class game : Control
{
	private Node _selectedDie;
	private PlayerState _playerState;
	private LogicDiceTray _logicDiceTray;
	private LogicDice _logicDice;
	private double _sinceLastInput = 0;
	public override void _Ready()
	{
		InitSignals();
		GetNode<RichTextLabel>("Gold/ColorRect/RichTextLabel").Text = "10";
		_playerState = PlayerState.None;
		_logicDice = new LogicDice(this);
		_logicDiceTray = new LogicDiceTray(this, _logicDice);
	}
	private void InitSignals()
	{
		var buttonPlay = GetNode<Button>("Button");
		var buttonRoll = GetNode<Button>("Dicetraybutton/ButtonRoll");
		var buttonAdd = GetNode<Button>("Dicetraybutton/ButtonAdd");
		var CardWithDice = GetTree().GetNodesInGroup("CardWithDice");

		buttonRoll.Pressed += _on_button_roll_pressed;
		buttonAdd.Pressed += _on_button_add_pressed;
		buttonPlay.Pressed += _on_button_play_pressed;

		foreach (CardWithDice c in CardWithDice)
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
					var dVal = _logicDice.GetDieValue(_selectedDie);
					DeselectDie();
					if (dVal == i)
						return;
				}

				_selectedDie = _logicDiceTray.TrySelectDie(i);
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
		var dList = GetNode<Node>("Dicetraybutton/DieTray/GridContainer");
		foreach (Control item in dList.GetChildren())
		{
			_logicDice.RollDie(item);
		}
	}
	private void _on_button_add_pressed()
	{
		if (!TryPay(2))
			return;
		_logicDiceTray.AddDie();
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
		_logicDice.ToggleDieColorSelected(_selectedDie);
		_playerState = PlayerState.None;
		_selectedDie = null;
	}
	private void ShowAddDieButtons(bool isVisible)
	{
		foreach (CardWithDice n in GetTree().GetNodesInGroup("CardWithDice"))
		{
			if(n.GetNode("ColorRect/GridContainer").GetChildCount() != 0)
				continue;
				
			n.GetNode<Button>("ColorRect/Button").Visible = isVisible;
		}
	}
	private bool TryPay(int cost)
	{
		var amountNode = GetNode<RichTextLabel>("Gold/ColorRect/RichTextLabel");
		if (amountNode.Text.ToInt() < cost)
			return false;

		amountNode.Text = (amountNode.Text.ToInt() - cost).ToString();
		return true;
	}

	
	private void _on_button_play_pressed()
	{
		//1. Alla kort effekter
		//2. Alla kostnads effekter
		//3. Alla event effekter
	}
}
