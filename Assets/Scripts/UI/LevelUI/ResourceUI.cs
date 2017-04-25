using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ResourceMode
{
    Produced, Required, Consumed
}

public class ResourceUI : MonoBehaviour {

    public Image icon;
    public Sprite normalIcon;
    public Sprite missingIcon;
    public Sprite requiredIcon;

    public void Init(ResourceMode mode)
    {
        switch (mode)
        {
            case ResourceMode.Produced:
                icon.sprite = normalIcon;
                break;
            case ResourceMode.Consumed:
                icon.sprite = missingIcon;
                break;
            case ResourceMode.Required:
                icon.sprite = requiredIcon;
                break;
            default:
                throw new System.Exception("Unrecognized enum value " + mode.ToString());
        }
    }
}
