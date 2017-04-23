using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrganismTooltip : MonoBehaviour {
    
    [SerializeField] private Text organismName;
    [SerializeField] private GameObject iconParent;
    [SerializeField] private GameObject producesIconParent;
    [SerializeField] private GameObject consumesIconParent;
    [SerializeField] private GameObject requiresIconParent;
    
	public void SetOrganism(EOrganism type)
    {
        organismName.text = type.ToString().Replace('_', ' ');
        Instantiate(OrganismMap.Obj.GetIconPrefab(type), iconParent.transform);

        Organism organism = OrganismLibrary.GetOrganismFor(type);

        foreach (Resource produces in organism.ProducedResources)
            Instantiate(ResourceMap.Obj.GetResourcePrefab(produces), producesIconParent.transform).Init(ResourceMode.Produced);

        foreach (Resource consumes in organism.ConsumedResources)
            Instantiate(ResourceMap.Obj.GetResourcePrefab(consumes), consumesIconParent.transform).Init(ResourceMode.Consumed);

        foreach (Resource requires in organism.ConsumedResources)
            Instantiate(ResourceMap.Obj.GetResourcePrefab(requires), requiresIconParent.transform).Init(ResourceMode.Required);
    }
}
