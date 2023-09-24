using System;
using System.Linq;
using Godot;

public static class LogicDiceTray
{

    public static Die? TrySelectDie(int i, Root root)
    {
        Die mDieToSelect = TryGetDieWithValue(i, root);
        if (mDieToSelect is null)
            return null;

        LogicDice.ToggleDieColorSelected(mDieToSelect);
        return mDieToSelect;
    }

    public static void AddDie(Root root)
    {
        var dList = root.GetNode<Control>("Dicetray/GridContainer");
        PackedScene DieScene = (PackedScene)GD.Load("res://stuff/Die.tscn");
        dList.AddChild(DieScene.Instantiate());
    }

    private static Die? TryGetDieWithValue(int i, Root root)
    {
        var res = root.GetNode<Control>("Dicetray/GridContainer")
            .GetChildren()
            .FirstOrDefault(x =>
            {
                var dVal = LogicDice.GetDieValue((Die)x);
                return dVal == i;
            });
        return (Die)res;
    }
}