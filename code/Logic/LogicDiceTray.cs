using System;
using System.Linq;
using Godot;

public class LogicDiceTray : Logic
{
    private readonly LogicDice _logicDice;
    public LogicDiceTray(Node root, LogicDice logicDice) : base(root)
    {
        _logicDice = logicDice;
    }

    public Node? TrySelectDie(int i)
    {
        var mDieToSelect = TryGetDieWithValue(i);
        if (mDieToSelect is null)
            return null;

        _logicDice.ToggleDieColorSelected(mDieToSelect);
        return mDieToSelect;
    }

    public void AddDie()
    {
        var dList = _root.GetNode<Node>("Dicetraybutton/DieTray/GridContainer");
        PackedScene DieScene = (PackedScene)GD.Load("res://stuff/Die.tscn");
        dList.AddChild(DieScene.Instantiate());
    }

    private Node? TryGetDieWithValue(int i)
    {
        return _root.GetNode<Node>("Dicetraybutton/DieTray/GridContainer")
            .GetChildren()
            .FirstOrDefault(x =>
            {
                var dVal = _logicDice.GetDieValue(x);
                return dVal == i;
            });
    }
}