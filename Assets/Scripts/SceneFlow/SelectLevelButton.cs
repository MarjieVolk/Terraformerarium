using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SelectLevelButton : MonoBehaviour {

    public string level;

	// Use this for initialization
	void Start () {
        this.GetComponent<Button>().onClick.AddListener(() => SceneHelper.Obj.GoToLevel(level));
	}
}
