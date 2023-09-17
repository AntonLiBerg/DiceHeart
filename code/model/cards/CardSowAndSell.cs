using Godot;
using System;
using System.Linq;

public partial class CardSowAndSell : ICard
{
	public override int MaxNrOfDice { get; protected set; } = 8;
	public override int MinNrOfDice { get; protected set; } = 1;
	public int MinDieQuality { get; private set; } = 4;
	public int Progress { get; private set; } = 0;
	public int Reward { get; private set; } = 12;

	public override bool DieMeetsReqs(Node die)
		=> LogicDice.GetDieValue(die) >= MinDieQuality;

	public override void UpdateGame(Node root)
	{
		Progress += LogicCard
			.GetDice(this)
			.Count();

		if (Progress >= 3)
		{
			Progress = 0;
			var gold = root.GetNode<Label>("ResGold/Label");
			gold.Text = (gold.Text.ToInt() + Reward).ToString();
		}

		GetNode<Label>("Label4").Text = Progress.ToString();
		LogicCard.RemoveAllDice(this);
	}
}
