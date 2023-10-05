using Godot;

public abstract class IChange
{
    public abstract string Title { get; protected set; }
    public abstract string EachTurnLabel { get; protected set; }
    public abstract string PriceToEndLabel { get; protected set; }
    public abstract int PriceToEnd { get; protected set; }
    public abstract IChange GetNextChange();
    public abstract void UpdateGame(Root root);
    public abstract bool IsFinished();
    public abstract bool TryPay(Root root);
    public Change MakeChange(Root root)
    {
        
        Change c = (Change)((PackedScene)GD.Load("res://stuff/Change.tscn"))
            .Instantiate();
        c.GetNode<Label>("Label").Text = Title;
        c.GetNode<Label>("Label4").Text = EachTurnLabel;
        c.GetNode<Label>("Label5").Text = PriceToEndLabel;
        c.GetNode<Button>("Button")
            .Pressed += () =>
            {
                if(TryPay(root))
                    c.GetParent()
                        .RemoveChild(c);
            };
        return c;
    }
}