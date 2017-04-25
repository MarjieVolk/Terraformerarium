using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public enum EOrganism
{
    COW,
    GRASS,
    MOSQUITO,
    BLUE_JAY,
    APPLE_TREE,
    LETTUCE,
    WHEAT,
    RABBIT,
    FOX,
    COUGAR,
    HEN,
    SNAKE
}

public static class EOrganismExtensions
{
    public static string DisplayName(this EOrganism o)
    {
        return o.ToString().Replace('_', ' ');
    }
}
