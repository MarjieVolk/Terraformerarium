using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetPrefabDisplayer : MonoBehaviour {

    [SerializeField]
    private string targetLevel;

	// Use this for initialization
	void Start () {
        if (!string.IsNullOrEmpty(targetLevel))
            this.Display(this.targetLevel);
        else
            this.Display(SceneState.CurrentLevel);
	}
	
	private void Display(string levelName)
    {
        Instantiate(LevelMap.Obj.GetIconPrefab(levelName), this.transform);
    }
}
