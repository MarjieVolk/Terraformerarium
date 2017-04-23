using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcosystemResourcesUI : MonoBehaviour {

    [SerializeField] private EcosystemComponent ecosystem;
    [SerializeField] private GameObject container;
	
    public void Start()
    {
        this.Refresh();
    }
    
	public void Refresh()
    {
        while (container.transform.childCount > 0)
            Destroy(container.transform.GetChild(0));

        foreach (EResource missing in ecosystem.GetMissingResources())
        {
            Instantiate(ResourceMap.Obj.GetResourcePrefab(missing), container.transform).Init(true);
        }

        foreach (EResource unused in ecosystem.GetUnusedResources())
        {
            Instantiate(ResourceMap.Obj.GetResourcePrefab(unused), container.transform).Init(false);
        }
	}
}
