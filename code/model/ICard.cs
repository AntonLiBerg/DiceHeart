using System;
using System.Linq;
using Godot;

public abstract partial class ICard : Control
{

    public abstract int MaxNrOfDice { get; protected set; }
    public abstract int MinNrOfDice { get; protected set; }
	public bool IsRoomForDice()
		=> LogicCard
				.GetDice(this)
				.Count <= MaxNrOfDice;

    public bool HasDice()
        => LogicCard
            .GetDice(this)
            .Any();
    public abstract bool DieMeetsReqs(Node die);

    public abstract void UpdateGame(Node root);
}