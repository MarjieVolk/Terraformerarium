﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHelper : MonoBehaviour {

    public static SceneHelper Obj;

    public void Awake()
    {
        Obj = this;
        SceneState.RefreshCurrentCapsule();
    }

	public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GoToLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void GoToLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void GoToLeaderboard(string level)
    {
        SceneState.NextLeaderboardLevel = level;
        SceneManager.LoadScene("Leaderboard");
    }
}
