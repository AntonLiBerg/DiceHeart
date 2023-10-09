using Godot;

public class CrdPower : ICard
{
    public override string Title { get; protected set; } = "Power";
    public override string Description { get; protected set; } = "Xd[5+]: +1🛡️\n x = times card used + 1";
    public override Color BColor { get; protected set; } = Colors.AliceBlue;
    public override bool ShowProgress { get; protected set; } = true;
    public override string ProgressLabel { get; set; } = "Used:";
    public override int Progress { get; protected set; } = 1;
    public int Current { get; set; }

    public override bool DieMeetsReq(Die d)
        => LogicDice.GetDieValue(d) >= 5 && GetDice().Count < Progress;
    public override void UpdateGame(Root root)
    {
        if (GetDice().Count < Progress)
            return;

        LogicRes.Update(1,root.GetNode<Control>("ResPower"));
        Progress++;
        Card.GetNode<Label>("Label4").Text = Progress.ToString();
        RemoveAllDice();
    }
}