using Godot;
using System.Linq;

public partial class CardHeart : Control
{
	public int MaxNrOfDice { get; private set; } = 20;
	public int MinNrOfDice { get; private set; } = 1;
	public bool IsRoomForDice()
		=> LogicCard
				.GetDice(this)
				.Count <= MaxNrOfDice;

	public bool HasDice()
		=> LogicCard
			.GetDice(this)
			.Any();
	public void UpdateGame(Node root)
	{
		var res = root
			.GetNode<Label>("ResHeart/Label")
			.Text
			.ToInt();

		foreach (var d in LogicCard.GetDice(this))
		{
			res += LogicDice.GetDieValue(d);
		}
		
		root
			.GetNode<Label>("ResHeart/Label")
			.Text = res.ToString();
		LogicCard.RemoveAllDice(this);
	}
}
