using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelSelectButton : MonoBehaviour
{
    public void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(() => SceneHelper.Obj.GoToLevelSelect());
    }
}
