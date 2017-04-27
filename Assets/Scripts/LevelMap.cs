using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class LevelMapping
{
    public string LevelName;
    public string PlanetName;
    public Image IconPrefab;
}

public class LevelMap : MonoBehaviour
{
    public static LevelMap Obj;

    [SerializeField] private LevelMapping[] Map;
    private Dictionary<string, LevelMapping> map;

    // Use this for initialization
    void Awake()
    {
        Obj = this;

        map = new Dictionary<string, LevelMapping>();
        foreach (LevelMapping mapping in Map)
        {
            map[mapping.LevelName] = mapping;
        }
    }

    public string GetPlanetName(string levelName)
    {
        return map[levelName].PlanetName;
    }

    public Image GetIconPrefab(string levelName)
    {
        return map[levelName].IconPrefab;
    }
}
