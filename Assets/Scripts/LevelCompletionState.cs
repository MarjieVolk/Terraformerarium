﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class LevelCompletionState
{
    private const string NumCompletedKey = "NumLevelsCompleted";

    public static int NumberOfLevelsCompleted()
    {
        if (!PlayerPrefs.HasKey(NumCompletedKey))
            PlayerPrefs.SetInt(NumCompletedKey, 0);

        return PlayerPrefs.GetInt(NumCompletedKey);
    }

    public static void CompleteLevel(string levelName, int score)
    {
        if (!PlayerPrefs.HasKey(levelName))
        {
            PlayerPrefs.SetInt(NumCompletedKey, NumberOfLevelsCompleted() + 1);
            PlayerPrefs.SetInt(levelName, score);
        }
    }
}
