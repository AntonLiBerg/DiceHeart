using System;
using Godot;

public class AlCrimeWave : IAilment
{
    public override string Title { get; protected set; } = "Crime Wave";
    public override string Effect { get; protected set; } = "Risks structural problems. Have 2🛡️ to end";
    public override string Description { get => throw new NotImplementedException(); protected set => throw new NotImplementedException(); }

    public override bool TryPay(Root root)
    {
        throw new NotImplementedException();
    }

    public override void UpdateGame(Root root)
    {
        if (root.GetNode<Label>("ResPower/Label").Text.ToInt() >= 2)
        {
            RemoveThisChange(root);
            return;
        }
        if (new Random().Next(1, 3) != 1)
            return;

        RemoveThisChange(root);
        root.AddNewChange(new AlCrimeGang());
    }
}