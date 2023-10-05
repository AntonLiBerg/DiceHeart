using Godot;

public class CPoorHarvest : IChange
{
    public override string Title { get; protected set; } = "Poor Harvest";
    public override string EachTurnLabel { get; protected set; } = "-1🪙";
    public override string PriceToEndLabel { get; protected set; } = "2🪙";
    public override int PriceToEnd { get; protected set; } = 2;
    public override IChange GetNextChange()
        => new CEmptyChange();

    public override bool IsFinished()
    {
        return false;
    }

    public override bool TryPay(Root root)
    {
        if (root.TryPay(PriceToEnd))
            return true;
        return false;
    }

    public override void UpdateGame(Root root)
    {
        var amountNode = root.GetNode<Label>("ResGold/Label");
        amountNode.Text = (amountNode.Text.ToInt() - 2).ToString();
    }
}