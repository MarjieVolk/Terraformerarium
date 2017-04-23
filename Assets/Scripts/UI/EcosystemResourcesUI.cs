using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcosystemResourcesUI : MonoBehaviour {

    [SerializeField] private EcosystemReference ecosystem;
    [SerializeField] private GameObject container;
	
    public void Start()
    {
        this.Refresh();
        ecosystem.Ecosystem.OnOrganismsChanged += RefreshList;
    }
    
    public void RefreshList(Multiset<Organism> newList)
    {
        this.Refresh();
    }

	public void Refresh()
    {
        for (int i = 0; i < container.transform.childCount; i++)
            Destroy(container.transform.GetChild(i).gameObject);

        foreach (Resource missing in ecosystem.Ecosystem.GetMissingResources())
        {
            Instantiate(ResourceMap.Obj.GetResourcePrefab(missing), container.transform).Init(ResourceMode.Required);
        }

        foreach (Resource unused in ecosystem.Ecosystem.GetUnusedResources())
        {
            Instantiate(ResourceMap.Obj.GetResourcePrefab(unused), container.transform).Init(ResourceMode.Produced);
        }
	}

    public void OnDestroy()
    {
        ecosystem.Ecosystem.OnOrganismsChanged -= RefreshList;
    }
}
