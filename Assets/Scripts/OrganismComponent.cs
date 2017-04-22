using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganismComponent : MonoBehaviour, IOrganism
{
    //TODO editor init of these guys
    public Multiset<Resource> ProducedResources { get; }
    public Multiset<Resource> ConsumedResources { get; }
    public Multiset<Resource> RequiredResources { get; }

    public int MinimumHumidity { get; }
    public int MaximumHumidity { get; }

    public int MinimumSoilRichness { get; }
    public int MaximumSoilRichness { get; }

    public int MinimumTemperature { get; }
    public int MaximumTemperature { get; }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
