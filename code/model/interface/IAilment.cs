using Godot;

public abstract class IAilment : IChange
{
    public override Color Color { get; protected set; } = Colors.DarkRed;
}