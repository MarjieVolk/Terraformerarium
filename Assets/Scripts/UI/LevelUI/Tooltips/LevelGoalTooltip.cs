using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LevelGoalTooltip : MonoBehaviour {

    public Text text;

	// Use this for initialization
	void Start () {
        this.text.text = string.Join("\n\r", SceneState.GetCurrentLevel().LevelGoals.Select(goal => goal.DisplayString()).ToArray());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
