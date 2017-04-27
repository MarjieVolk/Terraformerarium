using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class PlanetNameDisplayer : MonoBehaviour {

    [SerializeField]
    private string targetLevel;

	// Use this for initialization
	void Start () {
        if (!string.IsNullOrEmpty(targetLevel))
            this.DisplayLevel(targetLevel);
        else
            this.DisplayLevel(SceneState.CurrentLevel);
	}

    private void DisplayLevel(string levelName)
    {
        this.GetComponent<Text>().text = LevelMap.Obj.GetPlanetName(levelName).ToUpper();
    }
}
