using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EcosystemComponent : MonoBehaviour, IEcosystem
{
    // these are all properties inferred from the scene graph
    public HashSet<IOrganism> ContainedOrganisms
    {
        get
        {
            return new HashSet<IOrganism>(GetComponentsInChildren<OrganismComponent>());
        }
    }

    public int Humidity
    {
        get
        {
            return ContainedOrganisms.Select((org) => org.HumidityMod).Sum();
        }
    }

    public int SoilRichness
    {
        get
        {
            return ContainedOrganisms.Select((org) => org.SoilRichnessMod).Sum();
        }
    }

    public int Temperature
    {
        get
        {
            return ContainedOrganisms.Select((org) => org.TemperatureMod).Sum();
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MergeFrom(EcosystemComponent other)
    {
        // reparent the organisms in the other environment to this environment
        foreach (OrganismComponent organism in other.GetComponentsInChildren<OrganismComponent>())
        {
            organism.transform.parent = transform;
        }
    }
}
