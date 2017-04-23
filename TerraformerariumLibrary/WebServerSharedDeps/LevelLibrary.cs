using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class LevelLibrary
{
    private static Dictionary<string, Level> Library = new Dictionary<string, Level>();

    public static Level GetLevelFor(string canonicalName)
    {
        Level level;
        Library.TryGetValue(canonicalName, out level);

        return level;
    }

    public static void RegisterLevel(string canonicalName, Level level)
    {
        Library[canonicalName] = level;
    }
}
