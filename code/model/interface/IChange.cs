using Godot;

public abstract class IChange
{
    public Control Change { get; protected set; }
    public abstract string Title { get; protected set; }
    public abstract string Effect { get; protected set; }
    public abstract string Description { get; protected set; }
    public abstract Color Color { get; protected set; }
    public abstract void UpdateGame(Root root);
    public abstract bool TryPay(Root root);
    public void MakeChange(Root root)
    {

        Token c = (Token)((PackedScene)GD.Load("res://stuff/Token.tscn"))
            .Instantiate();
        c.GetNode<Label>("Label").Text = Title;
        c.GetNode<Label>("Label2").Text = Effect;
        c.GetNode<ColorRect>("ColorRect").Color = Color;
        root.GetNode<Control>("Changes")
            .AddChild(c);
        
        Change = c;
    }
    public void RemoveThisChange(Root root)
    {
        Change.GetParent()
            .RemoveChild(Change);
        root.Changes.Remove(this);
    }
}