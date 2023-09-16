using System;
using System.Linq;
using Godot;

public static class LogicDiceTray
{

    public static Node? TrySelectDie(int i, Node root)
    {
        var mDieToSelect = TryGetDieWithValue(i, root);
        if (mDieToSelect is null)
            return null;

        LogicDice.ToggleDieColorSelected(mDieToSelect);
        return mDieToSelect;
    }

    public static void AddDie(Node root)
    {
        var dList = root.GetNode<Node>("Dicetray/GridContainer");
        PackedScene DieScene = (PackedScene)GD.Load("res://stuff/Die.tscn");
        dList.AddChild(DieScene.Instantiate());
    }

    private static Node? TryGetDieWithValue(int i, Node root)
    {
        return root.GetNode<Node>("Dicetray/GridContainer")
            .GetChildren()
            .FirstOrDefault(x =>
            {
                var dVal = LogicDice.GetDieValue(x);
                return dVal == i;
            });
    }
}