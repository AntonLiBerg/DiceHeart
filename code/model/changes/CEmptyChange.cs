public class CEmptyChange : IChange
{
    public override string Title { get => throw new System.NotImplementedException(); protected set => throw new System.NotImplementedException(); }
    public override string EachTurnLabel { get => throw new System.NotImplementedException(); protected set => throw new System.NotImplementedException(); }
    public override string PriceToEndLabel { get => throw new System.NotImplementedException(); protected set => throw new System.NotImplementedException(); }
    public override int PriceToEnd { get => throw new System.NotImplementedException(); protected set => throw new System.NotImplementedException(); }

    public override IChange GetNextChange()
    {
        throw new System.NotImplementedException();
    }

    public override bool IsFinished()
    {
        return true;
    }

    public override bool TryPay(Root root)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateGame(Root root)
    {
        throw new System.NotImplementedException();
    }
}