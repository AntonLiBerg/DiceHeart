using System;
using Godot;

public class AlCorruption : IAilment
{
    public override string Title { get; protected set; } = "Corruption";
    public override string Effect { get; protected set; } = $"11+🪙:-4🪙 5+🎲:-3🎲";
    public int Counter { get; set; } = 0;
    public override string Description { get => throw new NotImplementedException(); protected set => throw new NotImplementedException(); }

    public override bool TryPay(Root root)
    {
        throw new NotImplementedException();
    }

    public override void UpdateGame(Root root)
    {
        if (Counter == 5)
        {
            RemoveThisChange(root);
            return;
        }
        if (root.GetNode<Label>("ResGold/Label").Text.ToInt() >= 10)
            LogicRes.Update(-4, root.GetNode<Control>("ResGold"));
        if (LogicDiceTray.GetNrOfDice(root) >= 5)
            LogicDiceTray.RemoveDice(3, root);

        Counter++;
    }
}