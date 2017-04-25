using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public static UIManager Obj;

    [SerializeField]
    private Popup messagePopupPrefab;

    public void Awake()
    {
        Obj = this;
    }

	public GameObject OpenPopup(GameObject prefab)
    {
        return Instantiate(prefab, this.transform);
    }

    public Popup OpenMessagePopup(string text, string title)
    {
        Popup popup = OpenMessagePopup(text);
        popup.Init(text, title);
        return popup;
    }

    public Popup OpenMessagePopup(string text)
    {
        Popup popup = Instantiate(messagePopupPrefab, this.transform);
        popup.Init(text);
        return popup;
    }

}
