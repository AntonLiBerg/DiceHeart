using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class game : Control
{
	public Root Root;
	public double SinceLastInput = 0;
	public override void _Ready()
	{
		GD.Print("ReadyG!");
	}

	public override void _Process(double delta)
	{
		SinceLastInput += delta;
		if (SinceLastInput < 0.1)
			return;
		if (Root is null)
			Root = new Root(this);
			
		Root.Process(delta);
	}

}
