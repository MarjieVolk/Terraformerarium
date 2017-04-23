using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceUI : MonoBehaviour {

    public Image icon;
    public Sprite normalIcon;
    public Sprite missingIcon;

	public void Init(bool isMissing)
    {
        if (isMissing)
            icon.sprite = missingIcon;
        else
            icon.sprite = normalIcon;
    }
}
