using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcosystemOrganismListUI : MonoBehaviour {

    [SerializeField] private EcosystemReference ecosystem;

	// Use this for initialization
	protected void Start()
    {
        ecosystem.Ecosystem.OnOrganismsChanged += Refresh;
        this.Refresh(ecosystem.Ecosystem.ContainedOrganisms);
	}
	
	private void Refresh(Multiset<Organism> newOrganisms)
    {
        for (int i = 0; i < this.transform.childCount; i++)
            Destroy(this.transform.GetChild(i));

        foreach (Organism o in newOrganisms)
            Instantiate(OrganismMap.Obj.GetIconPrefab(o.Type), this.transform);
    }

    protected void OnDestroy()
    {
        ecosystem.Ecosystem.OnOrganismsChanged -= Refresh;
    }
}
