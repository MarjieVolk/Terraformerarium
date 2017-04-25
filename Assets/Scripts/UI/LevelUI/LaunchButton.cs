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
        // check if the capsule is a self-sustaining ecosystem
        Multiset<Organism> unsupported = SceneState.CurrentCapsule.GetUnsupportedOrganisms();
        if (unsupported.Count > 0)
        {
            string unsupportedString = string.Join(", ", unsupported.Select(org => org.Type.DisplayName()).ToArray());
            UIManager.Obj.OpenMessagePopup(unsupportedString + " would die!", "Invalid capsule!");
            return;
        }

        // Check if number of organisms in capsule is valid
        int currentOrganisms = SceneState.CurrentCapsule.ContainedOrganisms.Count;
        int maxOrganisms = SceneState.GetCurrentLevel().MaxOrganismsPerCapsule;
        if (currentOrganisms > maxOrganisms)
        {
            UIManager.Obj.OpenMessagePopup(currentOrganisms + " present.  Max allowed is " + maxOrganisms, "Too many organisms!");
            return;
        }
        
        SceneState.CurrentSolution.AddCapsule(SceneState.CurrentCapsule);
        SceneState.RefreshCurrentCapsule();

        // reset the UIs
        SceneState.NotifyStateUpdated();

        if (SceneState.CurrentSolution.MeetsGoalRequirements())
        {
            // Win!
            LevelCompletionState.CompleteLevel(SceneState.CurrentLevel, SceneState.CurrentSolution.GetScore());
            SceneHelper.Obj.GoToLeaderboard(SceneState.CurrentLevel);
        }
    }
}
