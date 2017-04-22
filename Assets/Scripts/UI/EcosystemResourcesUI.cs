using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcosystemResourcesUI : MonoBehaviour {

    private EcosystemComponent ecosystem;
    [SerializeField] private GameObject container;
	
    // TODO Refresh when ecosystem changes
	public void Refresh()
    {
        while (container.transform.childCount > 0)
            Destroy(container.transform.GetChild(0));

        foreach (Resource missing in ecosystem.GetMissingResources())
        {
            Instantiate(ResourceMap.Obj.GetResourcePrefab(missing), container.transform).Init(true);
        }

        foreach (Resource unused in ecosystem.GetUnusedResources())
        {
            Instantiate(ResourceMap.Obj.GetResourcePrefab(unused), container.transform).Init(false);
        }
	}

    public void SetEcosystem(EcosystemComponent ecosystem)
    {
        this.ecosystem = ecosystem;
        this.Refresh();
    }
}
