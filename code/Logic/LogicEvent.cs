using System.Collections.Generic;
using System.Linq;
using Godot;

public static class LogicEvent
{
    public static List<Node> GetDice(IEvent gEvent)
    {
        return gEvent
            .GetNode("GridContainer")
            .GetChildren()
            .ToList<Node>();
    }
    public static bool IsRoomForDice(IEvent gEvent)
    {
        return (bool)gEvent
            .GetType()
            .GetMethod("IsRoomForDice")
            .Invoke(gEvent, null);
    }

    public static void CallUpdateGame(IEvent gEvent, Root root)
        => gEvent
        .GetType()
        .GetMethod("UpdateGame")
        .Invoke(gEvent, new object[] { root });

    public static void RemoveAllDice(IEvent gEvent)
        => GetDice(gEvent)
            .ForEach(d => d.QueueFree());

    public static bool DieMeetsReqs(IEvent gEvent, Node selectedDie)
        => (bool)gEvent
        .GetType()
        .GetMethod("DieMeetsReqs")
        .Invoke(gEvent, new object[] { selectedDie });
}