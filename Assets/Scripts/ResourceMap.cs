using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ResourceMapping
{
    public EResource type;
    public ResourceUI prefab;
}

public class ResourceMap : MonoBehaviour {

    public static ResourceMap Obj;

    public ResourceMapping[] Map;

    private Dictionary<EResource, ResourceUI> map;

	// Use this for initialization
	void Awake() {
        Obj = this;

        map = new Dictionary<EResource, ResourceUI>();
        foreach (ResourceMapping mapping in Map)
        {
            map[mapping.type] = mapping.prefab;
        }
	}
	
	public ResourceUI GetResourcePrefab(EResource resource)
    {
        return map[resource];
    }
}
