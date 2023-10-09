using System;
using Godot;

public class AlCorruption : IAilmentText
{
    public override string Title { get; protected set; } = "Corruption";
    public override string EachTurnLabel { get; protected set; } = $"If you have 11+🪙: -4🪙\nYou have 5+🎲: -3🎲\nLasts 5 turns";
    public override string PriceToEndLabel { get; protected set; }
    public override int PriceToEnd { get; protected set; }
    public override Color Color { get; protected set; } = Colors.DarkRed;
    public int Counter { get; set; } = 0;
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