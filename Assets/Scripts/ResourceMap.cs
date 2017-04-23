using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ResourceMapping
{
    public Resource type;
    public ResourceUI prefab;
}

public class ResourceMap : MonoBehaviour {

    public static ResourceMap Obj;

    public ResourceMapping[] Map;

    private Dictionary<Resource, ResourceUI> map;

	// Use this for initialization
	void Awake() {
        Obj = this;

        map = new Dictionary<Resource, ResourceUI>();
        foreach (ResourceMapping mapping in Map)
        {
            map[mapping.type] = mapping.prefab;
        }
	}
	
	public ResourceUI GetResourcePrefab(Resource resource)
    {
        return map[resource];
    }
}
