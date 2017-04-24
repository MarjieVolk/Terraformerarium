using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcosystemOrganismListUI : MonoBehaviour {

    [SerializeField] private EcosystemReference ecosystem;

	// Use this for initialization
	protected void Start()
    {
        SceneState.StateUpdated += Refresh;
        this.Refresh();
	}
	
	public void Refresh()
    {
        for (int i = 0; i < this.transform.childCount; i++)
            Destroy(this.transform.GetChild(i).gameObject);

        foreach (Organism o in ecosystem.Ecosystem.ContainedOrganisms)
            Instantiate(OrganismMap.Obj.GetIconPrefab(o.Type), this.transform);
    }

    protected void OnDestroy()
    {
        SceneState.StateUpdated -= Refresh;
    }
}
