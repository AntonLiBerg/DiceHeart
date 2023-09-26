using Godot;
using System;

public partial class EventWithDice : Control
{
	[Signal]
	public delegate void AddDieToEventEventHandler(Button emitter);
	private void _on_button_pressed()
	{
		var button = GetNode<Button>("Button");
		EmitSignal(SignalName.AddDieToEvent, button);
	}
}
