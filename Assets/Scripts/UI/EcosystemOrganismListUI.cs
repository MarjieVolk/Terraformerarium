using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcosystemOrganismListUI : MonoBehaviour {

    [SerializeField] private EcosystemReference ecosystem;
    [SerializeField] private OrganismTooltip organismTooltip;

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
        {
            GameObject instance = Instantiate(OrganismMap.Obj.GetIconPrefab(o.Type), this.transform).gameObject;
            HasOrganismTooltip hasTooltip = instance.AddComponent<HasOrganismTooltip>();
            hasTooltip.type = o.Type;
            hasTooltip.tooltipPrefab = organismTooltip;
        }
    }

    protected void OnDestroy()
    {
        SceneState.StateUpdated -= Refresh;
    }
}
