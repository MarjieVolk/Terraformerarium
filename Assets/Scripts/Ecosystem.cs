using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ecosystem : MonoBehaviour {
    // TODO these are all properties inferred from the scene graph
    private HashSet<Organism> ContainedOrganisms;
    private Multiset<Resource> ProducedResources;
    private Multiset<Resource> ConsumedResources;
    private Multiset<Resource> RequiredResources;
    private int Humidity;
    private int SoilRichness;
    private int Temperature;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
