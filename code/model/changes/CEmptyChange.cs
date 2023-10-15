using Godot;

public class CEmptyChange : IChange
{
    public override string Title { get => throw new System.NotImplementedException(); protected set => throw new System.NotImplementedException(); }
    public override string Effect { get => throw new System.NotImplementedException(); protected set => throw new System.NotImplementedException(); }
    public override string Description { get => throw new System.NotImplementedException(); protected set => throw new System.NotImplementedException(); }
    public override Color Color { get => throw new System.NotImplementedException(); protected set => throw new System.NotImplementedException(); }

    public override bool TryPay(Root root)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateGame(Root root)
    {
        throw new System.NotImplementedException();
    }
}