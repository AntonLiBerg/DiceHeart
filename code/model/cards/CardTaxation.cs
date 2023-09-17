using Godot;
using System;
using System.Linq;

public partial class CardTaxation : ICard
{
	public override int MaxNrOfDice { get; protected set; } = 8;
	public override int MinNrOfDice { get; protected set; } = 1;
	public override bool DieMeetsReqs(Node die)
		=> true;
	public override void UpdateGame(Node root)
	{
		var res = 0;

		foreach (var d in LogicCard.GetDice(this))
		{
			var dVal = LogicDice.GetDieValue(d);
			if (dVal <= 3)
				res += 2;
			else
				res += 3;
		}

		var heart = root.GetNode<Label>("ResGold/Label");
		heart.Text = (heart.Text.ToInt() + res).ToString();
		LogicCard.RemoveAllDice(this);
	}
}
