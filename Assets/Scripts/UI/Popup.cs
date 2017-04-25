using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour {

    [SerializeField] private Text title;
    [SerializeField] private Text text;

    public void Init(string text, string title)
    {
        this.Init(text);
        this.title.text = title;
    }

    public void Init(string text)
    {
        this.text.text = text;
    }

	public void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
