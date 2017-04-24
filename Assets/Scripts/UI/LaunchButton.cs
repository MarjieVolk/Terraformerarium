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
        // check if the capsule is a self-sustaining ecosystem
        if (SceneState.CurrentCapsule.GetUnsupportedOrganisms().Count > 0)
        {
            return;
        }
        
        SceneState.CurrentSolution.AddCapsule(SceneState.CurrentCapsule);
        SceneState.RefreshCurrentCapsule();

        // reset the UIs
        SceneState.NotifyStateUpdated();

        if (SceneState.CurrentSolution.MeetsGoalRequirements())
        {
            SceneHelper.Obj.GoToLeaderboard(SceneState.CurrentLevel);
        }
    }
}
