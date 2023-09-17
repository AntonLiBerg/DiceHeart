using Godot;
using System;
using System.Linq;

public partial class CardSowAndSell : Control
{
	public int MaxNrOfDice { get; private set; } = 8;
	public int MinNrOfDice { get; private set; } = 1;
	public int MinDieQuality { get; private set; } = 5;
	public int Progress { get; private set; } = 0;
	public bool IsRoomForDice()
		=> LogicCard
				.GetDice(this)
				.Count <= MaxNrOfDice;

	public bool HasDice()
		=> LogicCard
			.GetDice(this)
			.Any();

	public bool DieMeetsReqs(Node die)
		=> LogicDice.GetDieValue(die) >= MinDieQuality;

	public void UpdateGame(Node root)
	{
		Progress += LogicCard
			.GetDice(this)
			.Count();

		if (Progress >= 3)
		{
			Progress = 0;
			var gold = root.GetNode<Label>("ResGold/Label");
			gold.Text = (gold.Text.ToInt() + 6).ToString();
		}

		GetNode<Label>("Label4").Text = Progress.ToString();
		LogicCard.RemoveAllDice(this);
	}
}
