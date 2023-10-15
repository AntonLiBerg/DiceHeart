using Godot;

public abstract class IPopup
{
    public Popup Popup { get; set; }
    public abstract string Title { get; protected set; }
    public abstract string Description { get; protected set; }
    public abstract void SetButtons(Root root);
    public void ClosePopup(){
        Popup.QueueFree();
    }
    public void Make(Root root)
    {
        Popup = (Popup)((PackedScene)GD.Load("res://stuff/Popup.tscn"))
            .Instantiate();
        Popup.GetNode<Label>("Label").Text = Title;
        Popup.GetNode<Label>("Label2").Text = Description;
        SetButtons(root);
        root.Game.AddChild(Popup);
    }
}