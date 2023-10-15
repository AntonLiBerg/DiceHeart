using Godot;

public abstract class IBoon : IChange
{
    public override Color Color { get; protected set; } = Colors.DarkGreen;
}