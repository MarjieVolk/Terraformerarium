﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ExitButton : MonoBehaviour {
    
	void Start () {
        this.GetComponent<Button>().onClick.AddListener(() => Application.Quit());
	}
}
