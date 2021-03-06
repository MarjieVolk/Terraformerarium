﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrganismTooltip : MonoBehaviour {
    
    [SerializeField] private Text organismName;
    [SerializeField] private GameObject iconParent;
    [SerializeField] private GameObject producesIconParent;
    [SerializeField] private GameObject consumesIconParent;
    [SerializeField] private GameObject requiresIconParent;
    [SerializeField] private Gauge temperatureGauge;
    
	public void SetOrganism(EOrganism type)
    {
        organismName.text = type.DisplayName();
        Instantiate(OrganismMap.Obj.GetIconPrefab(type), iconParent.transform);

        Organism organism = OrganismLibrary.GetOrganismFor(type);

        temperatureGauge.SetHighlighted(organism.MinimumTemperature, organism.MaximumTemperature);

        foreach (Resource produces in organism.ProducedResources)
            Instantiate(ResourceMap.Obj.GetResourcePrefab(produces), producesIconParent.transform).Init(ResourceMode.Produced);

        foreach (Resource consumes in organism.ConsumedResources)
            Instantiate(ResourceMap.Obj.GetResourcePrefab(consumes), consumesIconParent.transform).Init(ResourceMode.Consumed);

        foreach (Resource requires in organism.RequiredResources)
            Instantiate(ResourceMap.Obj.GetResourcePrefab(requires), requiresIconParent.transform).Init(ResourceMode.Required);
    }
}
