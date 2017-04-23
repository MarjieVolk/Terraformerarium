using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.SceneManagement;

public static class SceneState
{
    public static Ecosystem CurrentCapsule { get; private set; }

    public static string CurrentLevel { get { return SceneManager.GetActiveScene().name; } }

    public static Level GetCurrentLevel()
    {
        return LevelLibrary.GetLevelFor(CurrentLevel);
    }

    public static void RefreshCurrentCapsule(int humidity = 0, int richness = 0, int temp = 0)
    {
        CurrentCapsule = new Ecosystem(humidity, richness, temp);
    }
}
