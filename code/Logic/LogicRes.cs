using Godot;

public static class LogicRes
{
    public static void Update(int change, Control node)
    {
        var l = node.GetNode<Label>("Label");
        l.Text = (l.Text.ToInt() + change).ToString();
    }
}