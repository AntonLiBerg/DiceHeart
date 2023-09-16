using System;
using System.Collections.Generic;
using System.Linq;
using Godot;

public static class LogicCard
{
    public static List<Node> GetDice(Node card)
    {
        return card
            .GetNode("CardWithDice/GridContainer")
            .GetChildren()
            .ToList<Node>();
    }
    public static bool IsRoomForDice(Node n)
    {
        return (bool)n
            .GetType()
            .GetMethod("IsRoomForDice")
            .Invoke(n, null);
    }

    public static void CallUpdateGame(Node n, Node root)
        => n
        .GetType()
        .GetMethod("UpdateGame")
        .Invoke(n, new object[] { root });
}