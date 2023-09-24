using Godot;
using System.Linq;

public partial class CardHeart : ICard
{
	public override int MaxNrOfDice { get; protected set; } = 8;
	public override int MinNrOfDice { get; protected set; } = 1;

	public override bool DieMeetsReqs(Die die)
		=> true;

	public override void UpdateGame(Root root)
	{
		var res = root
			.GetNode<Label>("ResHeart/Label")
			.Text
			.ToInt();

		foreach (Die d in LogicCard.GetDice(this))
		{
			res += LogicDice.GetDieValue(d);
		}

		if (res <= 0)
		{
			root.PlayerState = PlayerState.GameOverStart;
			return;
		}

		var heart = root.GetNode<Label>("ResHeart/Label");
		heart.Text = res.ToString();
		LogicCard.RemoveAllDice(this);
	}
}
