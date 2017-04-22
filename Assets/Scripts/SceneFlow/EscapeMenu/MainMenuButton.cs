using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MainMenuButton : MonoBehaviour {
    
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(() => SceneHelper.Obj.GoToMenu());
    }
}
