using Godot;

public class AlPoorHarvest : IAilment
{
    public override string Title { get; protected set; } = "Poor Harvest";
    public override string Effect { get; protected set; } = "-1🪙";
    public override Color Color { get; protected set; } = Colors.DarkRed;
    public override string Description { get => throw new System.NotImplementedException(); protected set => throw new System.NotImplementedException(); }

    public override bool TryPay(Root root)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateGame(Root root)
    {
        LogicRes.Update(-1,root.GetNode<Control>("ResGold"));
    }
}