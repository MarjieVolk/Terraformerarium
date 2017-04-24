using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class OrganismMapping
{
    public EOrganism type;
    public CanvasGroup iconPrefab;
    public GameObject prefab;
    public OrganismSlotType slotType;
}

public class OrganismMap : MonoBehaviour
{
    public static OrganismMap Obj;
    
    public OrganismMapping[] Map;

    private Dictionary<EOrganism, OrganismMapping> map;

    // Use this for initialization
    void Awake()
    {
        Obj = this;

        map = new Dictionary<EOrganism, OrganismMapping>();
        foreach (OrganismMapping mapping in Map)
        {
            map[mapping.type] = mapping;
        }
    }

    public OrganismSlotType GetSlotType(EOrganism organism)
    {
        return map[organism].slotType;
    }

    public GameObject GetPrefab(EOrganism organism)
    {
        return map[organism].prefab;
    }

    public CanvasGroup GetIconPrefab(EOrganism organism)
    {
        return map[organism].iconPrefab;
    }
}
