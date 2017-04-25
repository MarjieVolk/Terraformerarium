using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
[RequireComponent(typeof(PlaySfx))]
public class SelectLevelButton : MonoBehaviour
{
    public string level;
    public int completedLevelsRequired;

	// Use this for initialization
	void Start () {
        if (LevelCompletionState.NumberOfLevelsCompleted() >= completedLevelsRequired)
            this.GetComponent<Button>().onClick.AddListener(() => SceneHelper.Obj.GoToLevel(level));
        else
        {
            this.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            this.GetComponent<Button>().interactable = false;
            this.GetComponent<PlaySfx>().enabled = false;
        }
	}
}
