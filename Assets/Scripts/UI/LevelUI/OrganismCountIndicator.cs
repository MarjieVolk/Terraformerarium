using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class OrganismCountIndicator : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SceneState.StateUpdated += Refresh;
        Refresh();
	}
	
	private void Refresh()
    {
        int currentOrganisms = SceneState.CurrentCapsule.ContainedOrganisms.Count;
        int maxOrganisms = SceneState.GetCurrentLevel().MaxOrganismsPerCapsule;
        this.GetComponent<Text>().text = currentOrganisms + "/" + maxOrganisms;

        if (currentOrganisms > maxOrganisms)
            this.GetComponent<Text>().color = Color.red;
        else
            this.GetComponent<Text>().color = Color.white;
    }

    protected void OnDestroy()
    {
        SceneState.StateUpdated -= Refresh;
    }
}
