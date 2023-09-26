using Godot;
using System;
using System.Linq;

public partial class CardTaxation : ICard
{
	public override int MaxNrOfDice { get; protected set; } = 8;
	public override int MinNrOfDice { get; protected set; } = 1;
	public override bool DieMeetsReqs(Die die)
		=> true;
	public override void UpdateGame(Root root)
	{
		var res = 0;

		foreach (Die d in LogicCard.GetDice(this))
		{
			var dVal = LogicDice.GetDieValue(d);
			if (dVal <= 3)
				res += 2;
			else
				res += 3;
		}

		var coins = root.GetNode<Label>("ResGold/Label");
		coins.Text = (coins.Text.ToInt() + res).ToString();
		LogicCard.RemoveAllDice(this);
	}
}
