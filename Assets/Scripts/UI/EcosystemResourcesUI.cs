using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcosystemResourcesUI : MonoBehaviour {
    // TODO this isn't editor injectable anymore
    private Ecosystem ecosystem;
    [SerializeField] private GameObject container;
	
    public void Start()
    {
        this.Refresh();
    }
    
	public void Refresh()
    {
        for (int i = 0; i < container.transform.childCount; i++)
            Destroy(container.transform.GetChild(i).gameObject);

        foreach (Resource missing in ecosystem.GetMissingResources())
        {
            Instantiate(ResourceMap.Obj.GetResourcePrefab(missing), container.transform).Init(true);
        }

        foreach (Resource unused in ecosystem.GetUnusedResources())
        {
            Instantiate(ResourceMap.Obj.GetResourcePrefab(unused), container.transform).Init(false);
        }
	}
}
