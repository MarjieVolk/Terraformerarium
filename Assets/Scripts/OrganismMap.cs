﻿using System;
using System.Collections.Generic;
using Assets.Scripts.WebServerSharedDeps;
using UnityEngine;

[Serializable]
public class OrganismMapping
{
    public EOrganism type;
    public OrganismIconUI iconPrefab;
    public OrganismUI prefab;
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

    public OrganismUI GetPrefab(EOrganism organism)
    {
        return map[organism].prefab;
    }

    public OrganismIconUI GetIconPrefab(EOrganism organism)
    {
        return map[organism].iconPrefab;
    }
}