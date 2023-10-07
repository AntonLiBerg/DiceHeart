using Godot;

public abstract class IChange
{
    public Control Change { get; protected set; }
    public abstract string Title { get; protected set; }
    public abstract string EachTurnLabel { get; protected set; }
    public abstract string PriceToEndLabel { get; protected set; }
    public abstract int PriceToEnd { get; protected set; }
    public virtual bool ShowToEndNodes { get; protected set; } = true;
    public abstract Color Color { get; protected set; }
    public abstract void UpdateGame(Root root);
    public abstract bool TryPay(Root root);
    public abstract void MakeChange(Root root);
    public void RemoveThisChange(Root root)
    {
        Change.GetParent()
            .RemoveChild(Change);
        root.Changes.Remove(this);
    }
}