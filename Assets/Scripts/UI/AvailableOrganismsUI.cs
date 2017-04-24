using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailableOrganismsUI : MonoBehaviour {

    public OrganismIconUI organismIconPrefab;
    public EcosystemReference ecosystem;

	// Use this for initialization
	void Start () {
        List<Organism> organisms = SceneState.GetCurrentLevel().availableOrganisms;
        for (int i = 0; i < organisms.Count; i++)
        {
            OrganismIconUI instance = Instantiate(organismIconPrefab);
            instance.type = organisms[i].Type;
            instance.ecosystem = ecosystem;
            this.transform.GetChild(i).GetComponent<AddOrganismButton>().SetDisplay(instance);
        }
	}
}
