﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuInputListener : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
        {
            SceneHelper.Obj.GoToLevelSelect();
        }
	}
}
