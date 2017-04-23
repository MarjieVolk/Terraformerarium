using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganismComponent : MonoBehaviour, IOrganism
{
    public EOrganism OrganismType;

    private Organism Definition;

    public EOrganism Type { get { return Definition.Type; } }
    
    public Multiset<Resource> ProducedResources { get { return Definition.ProducedResources; } }
    public Multiset<Resource> ConsumedResources { get { return Definition.ConsumedResources; } }
    public Multiset<Resource> RequiredResources { get { return Definition.RequiredResources; } }

    public int MinimumHumidity { get { return Definition.MinimumHumidity; } }
    public int MaximumHumidity { get { return Definition.MaximumHumidity; } }
    public int HumidityMod { get { return Definition.HumidityMod; } }

    public int MinimumSoilRichness { get { return Definition.MinimumSoilRichness; } }
    public int MaximumSoilRichness { get { return Definition.MaximumSoilRichness; } }
    public int SoilRichnessMod {  get { return Definition.SoilRichnessMod; } }

    public int MinimumTemperature { get { return Definition.MinimumTemperature; } }
    public int MaximumTemperature { get { return Definition.MaximumTemperature; } }
    public int TemperatureMod { get { return Definition.TemperatureMod; } }

    public void SetDefinition(Organism definition)
    {
        Definition = definition;
    }

    // Use this for initialization
    void Start () {
        this.SetDefinition(OrganismLibrary.GetOrganismFor(this.OrganismType));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
