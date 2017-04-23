using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Ecosystem
{
    public Multiset<Organism> ContainedOrganisms { get; set; }

    public event Action<Multiset<Organism>> OnOrganismsChanged;

    public void AddOrganism(Organism toAdd)
    {
        ContainedOrganisms.Add(toAdd);
        if (OnOrganismsChanged != null)
        {
            OnOrganismsChanged(ContainedOrganisms);
        }
    }

    public void AddOrganisms(IEnumerable<Organism> toAdd)
    {
        foreach (Organism o in toAdd)
            ContainedOrganisms.Add(o);
        OnOrganismsChanged(ContainedOrganisms);
    }

    public void RemoveOrganism(Organism toRemove)
    {
        ContainedOrganisms.Remove(toRemove);
        if (OnOrganismsChanged != null)
        {
            OnOrganismsChanged(ContainedOrganisms);
        }
    }

    public void RemoveOrganisms(IEnumerable<Organism> toRemove)
    {
        foreach (Organism o in toRemove)
            ContainedOrganisms.Remove(o);
        OnOrganismsChanged(ContainedOrganisms);
    }

    public Ecosystem(int initialHumidity, int initialSoilRichness, int initialTemperature, params Organism[] organisms)
    {
        InitialHumidity = initialHumidity;
        InitialSoilRichess = initialSoilRichness;
        InitialTemperature = initialTemperature;
        ContainedOrganisms = new Multiset<Organism>(organisms);
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
        return ContainedOrganisms.Select((org) => org.RequiredResources).Aggregate(new Multiset<Resource>(), MultisetExtensions.MultisetMaxUnion);
    }

    public Multiset<Resource> GetMissingResources()
    {
        return new Multiset<Resource>(GetConsumedResources().Union(GetRequiredResources())).MultisetDifference(GetProducedResources());
    }

    public Multiset<Resource> GetUnusedResources()
    {
        return GetProducedResources().MultisetDifference(new Multiset<Resource>(GetConsumedResources().Union(GetRequiredResources())));
    }

    public Multiset<Organism> GetUnsupportedOrganisms()
    {
        Multiset<Resource> missingResources = GetMissingResources();

        return new Multiset<Organism>(ContainedOrganisms.Where(
            (org) => missingResources.Intersect(org.ConsumedResources).Count() > 0
            || missingResources.Intersect(org.RequiredResources).Count() > 0
            || !org.CanSurviveInClimateOf(this)));
    }
}
