using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceUI : MonoBehaviour {

    public Image icon;

	public void Init(bool isMissing)
    {
        if (isMissing)
            icon.color = Color.red;
    }
}
