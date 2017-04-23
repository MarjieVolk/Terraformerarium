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
    [SerializeField]
    private int humidityMod;

    public int MinimumHumidity { get { return minimumHumidity; } }
    public int MaximumHumidity { get { return maximumHumidity; } }
    public int HumidityMod { get { return humidityMod; } }

    [SerializeField]
    private int minimumSoilRichness;
    [SerializeField]
    private int maximumSoilRichness;
    [SerializeField]
    private int soilRichnessMod;

    public int MinimumSoilRichness { get { return minimumSoilRichness; } }
    public int MaximumSoilRichness { get { return maximumSoilRichness; } }
    public int SoilRichnessMod {  get { return soilRichnessMod; } }

    [SerializeField]
    private int minimumTemperature;
    [SerializeField]
    private int maximumTemperature;
    [SerializeField]
    private int temperatureMod;

    public int MinimumTemperature { get { return minimumTemperature; } }
    public int MaximumTemperature { get { return maximumTemperature; } }
    public int TemperatureMod { get { return temperatureMod; } }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
