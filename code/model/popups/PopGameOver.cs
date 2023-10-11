using Godot;

public class PopGameOver : IPopup
{
    public override string Title { get; protected set; } = "Game Over";
    public override string Description { get; protected set; } = "Flowers start to bow\nLeaves fall, winter's chill draws near\nStillness marks the end";

    public override void SetButtons(Root root)
    {
        Popup.GetNode<Button>("Button").Visible = true;
        Popup.GetNode<Button>("Button").Text = "Try Again";
        Popup.GetNode<Button>("Button").Pressed += () =>
        {
            root.GetTree()
                .ReloadCurrentScene();
        };
    }
}