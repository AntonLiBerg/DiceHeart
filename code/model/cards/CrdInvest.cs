using System.Linq;
using System.Reflection.Metadata.Ecma335;
using Godot;

public class CrdInvest : ICard
{
    public override string Title { get; protected set; } = "Invest";
    public override string Description { get; protected set; } = "d[4+] = +1 Progress \n2 Progress: +10🪙";
    public override bool ShowProgress { get; protected set; } = true;
    public override Color BColor { get; protected set; } = Colors.LightGreen;

    public override bool DieMeetsReq(Die d)
        => LogicDice.GetDieValue(d) >= 4;

    public override void UpdateGame(Root root)
    {
        Progress += GetDice().Count();

        if (Progress >= 2)
        {
            Progress = 0;
            var gold = root.GetNode<Label>("ResGold/Label");
            gold.Text = (gold.Text.ToInt() + 10).ToString();
        }

        Card.GetNode<Label>("Label4").Text = Progress.ToString();
        RemoveAllDice();
    }
}