using Godot;

public class CrdHeart : ICard
{
	public override string Title { get; protected set; } = "Heart";
	public override string Description { get; protected set; } = "d[x] = +x ♥️";
	public override Color BColor { get; protected set; } = Colors.PaleVioletRed;

	public override bool DieMeetsReq(Die d)
		=> true;

	public override void UpdateGame(Root root)
	{
		var res = root
			.GetNode<Label>("ResHeart/Label")
			.Text
			.ToInt();

		foreach (Die d in GetDice())
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
		RemoveAllDice();
	}
}