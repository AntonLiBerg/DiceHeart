using System;
using System.Linq;
using Godot;

public class LogicDice : Logic
{

    private Color DIE_SELECTED_COLOR
    {
        get { return new Color(0.8f, 0.8f, 0.8f); }
    }
    private Color DIE_COLOR
    {
        get { return new Color(0.45f, 0.45f, 0.45f); }
    }

    public LogicDice(Control root) : base(root)
    {
    }

    public void RollDie(Control c)
    {
        var textLabel = _root.GetNode<RichTextLabel>(c.GetPath().ToString() + "/ColorRect/RichTextLabel");
        var val = new Random().Next(1, 7);
        textLabel.Text = val.ToString();
    }
    public int GetDieValue(Node d)
    {
        return _root.GetNode<RichTextLabel>(d.GetPath().ToString() + "/ColorRect/RichTextLabel")
            .Text.ToInt();
    }
    public void ToggleDieColorSelected(Node d)
    {
        var dColor = _root.GetNode<ColorRect>(d.GetPath().ToString() + "/ColorRect");
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