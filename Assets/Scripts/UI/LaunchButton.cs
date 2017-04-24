using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LaunchButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SceneState.ResetSolution();
        GetComponent<Button>().onClick.AddListener(LaunchCapsule);
	}

    private void LaunchCapsule()
    {
        Debug.Log("Launch clicked.");
        // TODO check if the capsule is a self-sustaining ecosystem
        
        SceneState.CurrentSolution.AddCapsule(SceneState.CurrentCapsule);
        SceneState.RefreshCurrentCapsule();

        // TODO reset the UIs?
        SceneState.NotifyStateUpdated();
    }
}
