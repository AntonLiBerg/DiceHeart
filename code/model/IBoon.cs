using Godot;

public abstract class IBoon : IChange
{
    public bool ShowToEndNodes { get; protected set; } = false;
    public override void MakeChange(Root root)
    {

        Boon c = (Boon)((PackedScene)GD.Load("res://stuff/Boon.tscn"))
            .Instantiate();
        c.GetNode<Label>("Label").Text = Title;
        c.GetNode<Label>("Label4").Text = EachTurnLabel;
        c.GetNode<ColorRect>("ColorRect").Color = Color;
        c.GetNode<Button>("Button").Visible = ShowToEndNodes;
        c.GetNode<Label>("Label3").Visible = ShowToEndNodes;
        root.GetNode<Control>("Changes")
            .AddChild(c);
    }
}