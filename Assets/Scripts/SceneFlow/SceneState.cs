﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.SceneManagement;

public static class SceneState
{
    private static UserSolution _CurrentSolution;
    public static UserSolution CurrentSolution
    {
        get
        {
            if (_CurrentSolution == null)
            {
                ResetSolution();
            }

            return _CurrentSolution;
        }
        private set
        {
            _CurrentSolution = value;
        }
    }

    public static event Action StateUpdated;

    public static Ecosystem CurrentCapsule { get; private set; }

    public static string CurrentLevel { get { return SceneManager.GetActiveScene().name; } }

    public static string NextLeaderboardLevel { get; set; }

    public static Level GetCurrentLevel()
    {
        return LevelLibrary.GetLevelFor(CurrentLevel);
    }

    public static void RefreshCurrentCapsule(
        int humidity = OrganismDefinitions.Normal, int richness = OrganismDefinitions.Normal, int temp = OrganismDefinitions.Normal)
    {
        CurrentCapsule = new Ecosystem(humidity, richness, temp);
    }

    public static void ResetSolution()
    {
        CurrentSolution = new UserSolution(CurrentLevel, new List<Ecosystem>());
    }

    public static void NotifyStateUpdated()
    {
        if (StateUpdated != null)
        {
            StateUpdated();
        }
    }
}
