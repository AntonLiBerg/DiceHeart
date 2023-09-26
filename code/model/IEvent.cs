using System.Linq;
using Godot;

public abstract partial class IEvent : EventWithDice
{

    public abstract int MaxNrOfDice { get; protected set; }
    public abstract int MinNrOfDice { get; protected set; }
	public bool IsRoomForDice()
		=> LogicEvent
				.GetDice(this)
				.Count <= MaxNrOfDice;

    public bool HasDice()
        => LogicEvent
            .GetDice(this)
            .Any();
    public abstract bool DieMeetsReqs(Die die);

    public abstract void UpdateGame(Root root);
    public abstract bool IsEventFinished();
}