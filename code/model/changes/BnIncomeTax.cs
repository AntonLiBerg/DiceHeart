using System.Reflection.Metadata.Ecma335;
using Godot;

public class BnIncomeTax : IBoon
{
    public override string Title { get; protected set; } = "Income Tax";
    public override string EachTurnLabel { get; protected set; } = "+1🪙";
    public override string PriceToEndLabel { get; protected set; }
    public override int PriceToEnd { get; protected set; }
    public override Color Color { get; protected set; } = Colors.DarkGreen;

    public override IChange GetNextChange()
    {
        throw new System.NotImplementedException();
    }

    public override bool IsFinished()
        => false;

    public override bool TryPay(Root root)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateGame(Root root)
    {
        var gold = root.GetNode<Label>("ResGold/Label");
        gold.Text = (gold.Text.ToInt() + 1).ToString();
    }
}