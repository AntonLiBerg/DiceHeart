using Godot;

public class AlCrimeGang : IAilment
{
    public override string Title { get; protected set; } = "Crime Gang";
    public override string EachTurnLabel { get; protected set; } = "-2🪙 -1🛡️";
    public override string PriceToEndLabel { get; protected set; } = "have 5🛡️";
    public override int PriceToEnd { get; protected set; }
    public override Color Color { get; protected set; } = Colors.DarkRed;

    public override bool TryPay(Root root) => false;

    public override void UpdateGame(Root root)
    {
        var p = root.GetNode<Label>("ResPower/Label");
        if (p.Text.ToInt() >= 5)
        {
            RemoveThisChange(root);
            return;
        }

        LogicRes.Update(-2,root.GetNode<Control>("ResGold"));
        LogicRes.Update(-1,root.GetNode<Control>("ResPower"));
    }
}