using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LeaderboardLevelName : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        this.GetComponent<Text>().text = SceneState.NextLeaderboardLevel;
    }
}
