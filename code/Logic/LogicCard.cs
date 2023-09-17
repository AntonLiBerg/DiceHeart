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
    public static bool IsRoomForDice(Node card)
    {
        return (bool)card
            .GetType()
            .GetMethod("IsRoomForDice")
            .Invoke(card, null);
    }

    public static void CallUpdateGame(Node card, Node root)
        => card
        .GetType()
        .GetMethod("UpdateGame")
        .Invoke(card, new object[] { root });

    public static void RemoveAllDice(Node card)
        => GetDice(card)
            .ForEach(d => d.QueueFree());

    public static bool DieMeetsReqs(Node card, Node selectedDie)
        => (bool)card
        .GetType()
        .GetMethod("DieMeetsReqs")
        .Invoke(card, new object[] { selectedDie });
}