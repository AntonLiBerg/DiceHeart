using Godot;

public class AlPoorHarvest : IAilment
{
    public override string Title { get; protected set; } = "Poor Harvest";
    public override string EachTurnLabel { get; protected set; } = "-1🪙";
    public override string PriceToEndLabel { get; protected set; } = "2🪙";
    public override int PriceToEnd { get; protected set; } = 2;
    public override Color Color { get; protected set; } = Colors.DarkRed;

    public override bool TryPay(Root root)
    {
        if (root.TryPay(PriceToEnd))
            return true;
        return false;
    }

    public override void UpdateGame(Root root)
    {
        LogicRes.Update(-1,root.GetNode<Control>("ResGold"));
    }
}