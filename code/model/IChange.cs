using Godot;

public abstract class IChange
{
    public abstract string Title { get; protected set; }
    public abstract string EachTurnLabel { get; protected set; }
    public abstract string PriceToEndLabel { get; protected set; }
    public abstract int PriceToEnd { get; protected set; }
    public abstract Color Color { get; protected set; }
    public abstract IChange GetNextChange();
    public abstract void UpdateGame(Root root);
    public abstract bool IsFinished();
    public abstract bool TryPay(Root root);
    public IChange Change { get; protected set; }
    public abstract void MakeChange(Root root);
}