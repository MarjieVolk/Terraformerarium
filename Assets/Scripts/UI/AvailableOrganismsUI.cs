using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailableOrganismsUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
        foreach (IOrganism organism in SceneState.GetCurrentLevel().availableOrganisms)
        {
            Instantiate(OrganismMap.Obj.GetIconPrefab(organism.Type), this.transform);
        }
	}
}
