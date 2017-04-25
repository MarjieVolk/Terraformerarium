using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LaunchButton : MonoBehaviour {

    private int animationIndex = 0;
    private Animator animator;

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

        PlayNextAnimation();
    }

    private void PlayNextAnimation()
    {
        if (this.animator != null)
            animator.GetBehaviour<AnimationEventBroadcaster>().StateEntered -= PlayNextAnimation;

        while (animationIndex < this.transform.childCount && this.transform.GetChild(animationIndex).GetComponent<Animator>() == null)
            animationIndex++;

        if (animationIndex < this.transform.childCount)
        {
            animator = this.transform.GetChild(animationIndex).GetComponent<Animator>();
            animator.GetBehaviour<AnimationEventBroadcaster>().StateEntered += PlayNextAnimation;
            animator.SetBool("play", true);

            animationIndex++;
        } else
        {
            this.DoLaunch();
        }
    }

    private void DoLaunch()
    {
        this.animationIndex = 0;
        this.animator = null;

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
