using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Organism : MonoBehaviour
{
    //TODO editor init of these guys
    private Multiset<Resource> ProducedResources;
    private Multiset<Resource> ConsumedResources;
    private Multiset<Resource> RequiredResources;

    private int MinimumHumidity;
    private int MaximumHumidity;

    private int MinimumSoilRichness;
    private int MaximumSoilRichness;

    private int MinimumTemperature;
    private int MaximumTemperature;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
