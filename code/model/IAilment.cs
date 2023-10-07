using Godot;

public abstract class IAilment : IChange
{
    public override void MakeChange(Root root)
    {

        Ailment c = (Ailment)((PackedScene)GD.Load("res://stuff/Ailment.tscn"))
            .Instantiate();
        c.GetNode<Label>("Label").Text = Title;
        c.GetNode<Label>("Label4").Text = EachTurnLabel;
        c.GetNode<Label>("Label5").Text = PriceToEndLabel;
        c.GetNode<ColorRect>("ColorRect").Color = Color;
        c.GetNode<Button>("Button").Visible = ShowToEndNodes;
        c.GetNode<Label>("Label3").Visible = ShowToEndNodes;
        c.GetNode<Button>("Button")
            .Pressed += () =>
            {
                if (TryPay(root))
                    RemoveThisChange(root);

            };
        root.GetNode<Control>("Changes")
            .AddChild(c);

        Change = c;
    }
}