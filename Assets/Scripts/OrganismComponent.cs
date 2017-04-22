using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganismComponent : MonoBehaviour, IOrganism
{
    //TODO editor init of these guys
    public Multiset<Resource> ProducedResources { get; }
    public Multiset<Resource> ConsumedResources { get; }
    public Multiset<Resource> RequiredResources { get; }

    [SerializeField]
    private int minimumHumidity;
    [SerializeField]
    private int maximumHumidity;

    public int MinimumHumidity { get { return minimumHumidity; } }
    public int MaximumHumidity { get { return maximumHumidity; } }

    [SerializeField]
    private int minimumSoilRichness;
    [SerializeField]
    private int maximumSoilRichness;

    public int MinimumSoilRichness { get { return minimumSoilRichness; } }
    public int MaximumSoilRichness { get { return maximumSoilRichness; } }

    [SerializeField]
    private int minimumTemperature;
    [SerializeField]
    private int maximumTemperature;

    public int MinimumTemperature { get { return minimumTemperature; } }
    public int MaximumTemperature { get { return maximumTemperature; } }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
