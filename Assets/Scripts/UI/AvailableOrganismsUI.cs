using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailableOrganismsUI : MonoBehaviour {

    public OrganismIconUI organismIconPrefab;
    public EcosystemReference ecosystem;

	// Use this for initialization
	void Start () {
        foreach (Organism organism in SceneState.GetCurrentLevel().availableOrganisms)
        {
            OrganismIconUI instance = Instantiate(organismIconPrefab, this.transform);
            instance.type = organism.Type;
            instance.ecosystem = ecosystem;
        }
	}
}
