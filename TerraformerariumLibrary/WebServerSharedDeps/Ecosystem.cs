using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Ecosystem
{
    public Multiset<IOrganism> ContainedOrganisms { get; set; }

    public event Action<Multiset<IOrganism>> OnOrganismsChanged;

    public void AddOrganism(IOrganism toAdd)
    {
        ContainedOrganisms.Add(toAdd);
        OnOrganismsChanged(ContainedOrganisms);
    }

    public void RemoveOrganism(IOrganism toRemove)
    {
        ContainedOrganisms.Remove(toRemove);
        OnOrganismsChanged(ContainedOrganisms);
    }

    public Ecosystem(int initialHumidity, int initialSoilRichness, int initialTemperature, params IOrganism[] organisms)
    {
        InitialHumidity = initialHumidity;
        InitialSoilRichess = initialSoilRichness;
        InitialTemperature = initialTemperature;
        ContainedOrganisms = new Multiset<IOrganism>(organisms);
    }

    private int InitialHumidity, InitialSoilRichess, InitialTemperature;

    public int Humidity {
        get
        {
            return InitialHumidity + ContainedOrganisms.Select((org) => org.HumidityMod).Sum();
        }
    }

    public int SoilRichness
    {
        get
        {
            return InitialSoilRichess + ContainedOrganisms.Select((org) => org.SoilRichnessMod).Sum();
        }
    }

    public int Temperature
    {
        get
        {
            return InitialTemperature + ContainedOrganisms.Select((org) => org.TemperatureMod).Sum();
        }
    }

    public Multiset<Resource> GetProducedResources()
    {
        return new Multiset<Resource>(ContainedOrganisms.SelectMany((org) => org.ProducedResources));
    }

    public Multiset<Resource> GetConsumedResources()
    {
        return new Multiset<Resource>(ContainedOrganisms.SelectMany((org) => org.ConsumedResources));
    }

    public Multiset<Resource> GetRequiredResources()
    {
        return ContainedOrganisms.Select((org) => org.RequiredResources).Aggregate(MultisetExtensions.MultisetMaxUnion);
    }

    public Multiset<Resource> GetMissingResources()
    {
        return new Multiset<Resource>(GetConsumedResources().Union(GetRequiredResources())).MultisetDifference(GetProducedResources());
    }

    public Multiset<Resource> GetUnusedResources()
    {
        return GetProducedResources().MultisetDifference(new Multiset<Resource>(GetConsumedResources().Union(GetRequiredResources())));
    }

    public HashSet<IOrganism> GetUnsupportedOrganisms()
    {
        Multiset<Resource> missingResources = GetMissingResources();

        return new HashSet<IOrganism>(ContainedOrganisms.Where(
            (org) => missingResources.Intersect(org.ConsumedResources).Count() > 0
            || missingResources.Intersect(org.RequiredResources).Count() > 0
            || !org.CanSurviveInClimateOf(this)));
    }
}
