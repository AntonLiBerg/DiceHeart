using Godot;

public abstract class Logic
{
    protected Node _root { get; }

    protected Logic(Node root)
    {
        _root = root;
    }
}