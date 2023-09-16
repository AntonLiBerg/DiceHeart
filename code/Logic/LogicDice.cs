using System;
using System.Linq;
using Godot;

public static class LogicDice
{

    private static Color DIE_SELECTED_COLOR
    {
        get { return new Color(0.8f, 0.8f, 0.8f); }
    }
    private static Color DIE_COLOR
    {
        get { return new Color(0.45f, 0.45f, 0.45f); }
    }

    public static void RollDie(Node c)
    {
        var textLabel = c.GetNode<Label>("Label");
        var val = new Random().Next(1, 7);
        textLabel.Text = val.ToString();
    }
    public static int GetDieValue(Node d)
    {
        return d.GetNode<Label>("Label")
            .Text.ToInt();
    }
    public static void ToggleDieColorSelected(Node d)
    {
        var dColor = d.GetNode<ColorRect>("ColorRect");
        if (dColor.Color.R == DIE_SELECTED_COLOR.R &&
            dColor.Color.G == DIE_SELECTED_COLOR.G &&
            dColor.Color.B == DIE_SELECTED_COLOR.B
        )
        {
            dColor.Color = DIE_COLOR;
        }
        else
        {
            dColor.Color = DIE_SELECTED_COLOR;
        }
    }

}