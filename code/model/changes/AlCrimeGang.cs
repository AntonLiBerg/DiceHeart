using Godot;

public class AlCrimeGang : IAilment
{
    public override string Title { get; protected set; } = "Crime Gang";
    public override string Effect { get; protected set; } = "-2🪙. Have 5🛡️ to end";
    public override string Description { get => throw new System.NotImplementedException(); protected set => throw new System.NotImplementedException(); }

    public override bool TryPay(Root root)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateGame(Root root)
    {
        var p = root.GetNode<Label>("ResPower/Label");
        if (p.Text.ToInt() >= 5)
        {
            RemoveThisChange(root);
            return;
        }

        LogicRes.Update(-2,root.GetNode<Control>("ResGold"));
    }
}