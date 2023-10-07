using Godot;

public abstract class IBoon : IChange
{
    public override void MakeChange(Root root)
    {

        Boon c = (Boon)((PackedScene)GD.Load("res://stuff/Boon.tscn"))
            .Instantiate();
        c.GetNode<Label>("Label").Text = Title;
        c.GetNode<Label>("Label4").Text = EachTurnLabel;
        c.GetNode<Label>("Label5").Text = PriceToEndLabel;
        c.GetNode<ColorRect>("ColorRect").Color = Color;
        c.GetNode<Button>("Button").Visible = false;
        root.GetNode<Control>("Changes")
            .AddChild(c);
    }
}