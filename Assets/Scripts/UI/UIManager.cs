using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public static UIManager Obj;

    public void Awake()
    {
        Obj = this;
    }

	public GameObject OpenPopup(GameObject prefab)
    {
        return Instantiate(prefab, this.transform);
    }
}
