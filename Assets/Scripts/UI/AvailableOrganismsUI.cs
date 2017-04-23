using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailableOrganismsUI : MonoBehaviour {

    public OrganismIconUI organismIconPrefab;

	// Use this for initialization
	void Start () {
        foreach (IOrganism organism in SceneState.GetCurrentLevel().availableOrganisms)
        {
            OrganismIconUI instance = Instantiate(organismIconPrefab, this.transform);
            instance.type = organism.Type;
        }
	}
}
