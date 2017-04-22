using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHelper : MonoBehaviour {

    public static SceneHelper Obj;

    public void Awake()
    {
        Obj = this;
    }

	public void GoToMenu()
    {
        SceneState.CurrentLevel = null;
        SceneManager.LoadScene("Menu");
    }

    public void GoToLevelSelect()
    {
        SceneState.CurrentLevel = null;
        SceneManager.LoadScene("LevelSelect");
    }

    public void GoToLevel(string level)
    {
        SceneState.CurrentLevel = level;
        SceneManager.LoadScene(level);
    }

    public void GoToLeaderboard(string level)
    {
        SceneState.CurrentLevel = level;
        SceneManager.LoadScene("Leaderboard");
    }
}
