using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.SceneManagement;

public static class SceneState
{
    public static string CurrentLevel { get { return SceneManager.GetActiveScene().name; } }

    public static Level GetCurrentLevel()
    {
        return LevelLibrary.GetLevelFor(CurrentLevel);
    }
}
