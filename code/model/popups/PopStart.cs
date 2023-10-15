using Godot;

public class PopStart : IPopup
{
    public override string Title { get; protected set; } = "Diceheart";
    public override string Description { get; protected set; } = "Keep the heart beating!\nEnd every turn with atleast 1 ♥️\nEvery turn ♥️ is decreased by 1\nPress 1-6 to select a 🎲 of that number";

    public override void SetButtons(Root root)
    {
        Popup.GetNode<Button>("Button").Visible = true;
        Popup.GetNode<Button>("Button").Text = "Ok";
        Popup.GetNode<Button>("Button").Pressed += () =>
        {
            ClosePopup();
        };
    }
}