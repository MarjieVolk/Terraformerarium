using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcosystemComponent : MonoBehaviour, IEcosystem
{
    // TODO these are all properties inferred from the scene graph
    public HashSet<OrganismComponent> ContainedOrganisms { get; }
    public Multiset<Resource> ProducedResources { get; }
    public Multiset<Resource> ConsumedResources { get; }
    public Multiset<Resource> RequiredResources { get; }
    public int Humidity { get; }
    public int SoilRichness { get; }
    public int Temperature { get; }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
