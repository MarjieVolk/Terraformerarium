using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasScaler))]
public class ScreenResolutionEnforcer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RectTransform content = this.transform.GetChild(0) as RectTransform;
        float widthRatio = content.rect.width / Screen.width;
        float heightRatio = content.rect.height / Screen.height;
        this.GetComponent<CanvasScaler>().scaleFactor = 1 / Mathf.Max(heightRatio, widthRatio);
	}
}
