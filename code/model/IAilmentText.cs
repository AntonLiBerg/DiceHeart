using Godot;

public abstract class IAilmentText : IChange
{
    public override void MakeChange(Root root)
    {

        AilmentText c = (AilmentText)((PackedScene)GD.Load("res://stuff/AilmentText.tscn"))
            .Instantiate();
        c.GetNode<Label>("Label").Text = Title;
        c.GetNode<Label>("Label2").Text = EachTurnLabel;
        c.GetNode<ColorRect>("ColorRect").Color = Color;
        root.GetNode<Control>("Changes")
            .AddChild(c);

        Change = c;
    }
}