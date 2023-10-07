using Godot;

public class CEmptyChange : IAilment
{
    public override string Title { get => throw new System.NotImplementedException(); protected set => throw new System.NotImplementedException(); }
    public override string EachTurnLabel { get => throw new System.NotImplementedException(); protected set => throw new System.NotImplementedException(); }
    public override string PriceToEndLabel { get => throw new System.NotImplementedException(); protected set => throw new System.NotImplementedException(); }
    public override int PriceToEnd { get => throw new System.NotImplementedException(); protected set => throw new System.NotImplementedException(); }
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