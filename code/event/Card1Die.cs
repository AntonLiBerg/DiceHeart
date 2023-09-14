using Godot;
using System;

public partial class Card1Die : Control
{

	[Signal]
	public delegate void AddDieToCardEventHandler(Button emitter);

	private void _on_button_adddie_pressed()
	{
		var button = GetNode<Button>("ColorRect/Button");
		EmitSignal(SignalName.AddDieToCard, button);
	}
}


