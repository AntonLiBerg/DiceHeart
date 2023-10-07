using System;
using Godot;

public class AlCrimeWave : IAilment
{
    public override string Title { get; protected set; } = "Crime Wave";
    public override string EachTurnLabel { get; protected set; } = "Risk for structural problems";
    public override string PriceToEndLabel { get; protected set; } = "have 2🛡️";
    public override bool ShowToEndNodes { get; protected set; } = false;
    public override int PriceToEnd { get; protected set; }
    public override Color Color { get; protected set; } = Colors.DarkRed;

    public override bool TryPay(Root root) => false;

    public override void UpdateGame(Root root)
    {
        if (new Random().Next(1, 3) != 1)
            return;

        RemoveThisChange(root);
        root.AddNewChange(new AlCrimeGang());
    }
}