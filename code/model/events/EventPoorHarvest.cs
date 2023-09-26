using Godot;
using System;

public partial class EventPoorHarvest : IEvent
{
	public override int MaxNrOfDice { get; protected set; } = 8;
	public override int MinNrOfDice { get; protected set; } = 1;
	public int Progress { get; private set; } = 0;

	public override bool DieMeetsReqs(Die die)
		=> true;

	public override bool IsEventFinished()
		=> Progress >= 8;


	public override void UpdateGame(Root root)
	{
		foreach (Die d in LogicEvent.GetDice(this))
		{
			var v = LogicDice.GetDieValue(d);
			if (v < 5)
				Progress++;
			else
				Progress += 2;
		}
		if(IsEventFinished())
			return;
			
		var coins = root.GetNode<Label>("ResGold/Label");
		coins.Text = (coins.Text.ToInt() - 1).ToString();
		LogicEvent.RemoveAllDice(this);
	}

}
