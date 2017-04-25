using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Ecosystem
{
    public Multiset<Organism> ContainedOrganisms { get; set; }

    public void AddOrganism(Organism toAdd)
    {
        ContainedOrganisms.Add(toAdd);
    }

    public void AddOrganisms(IEnumerable<Organism> toAdd)
    {
        foreach (Organism o in toAdd)
            ContainedOrganisms.Add(o);
    }

    public void RemoveOrganism(Organism toRemove)
    {
        ContainedOrganisms.Remove(toRemove);
    }

    public void RemoveOrganisms(IEnumerable<Organism> toRemove)
    {
        foreach (Organism o in toRemove)
            ContainedOrganisms.Remove(o);
    }

    public Ecosystem(int initialHumidity, int initialSoilRichness, int initialTemperature, params Organism[] organisms)
    {
        InitialHumidity = initialHumidity;
        InitialSoilRichess = initialSoilRichness;
        InitialTemperature = initialTemperature;
        ContainedOrganisms = new Multiset<Organism>(organisms);
    }

    public Ecosystem(IEnumerable<Organism> organisms) : this(0, 0, 0, organisms.ToArray())
    {
        ContainedOrganisms = new Multiset<Organism>();
    }

    public Ecosystem(Ecosystem other) : this(other.InitialHumidity, other.InitialSoilRichess, other.InitialTemperature,
        other.ContainedOrganisms.ToArray())
    {
        ContainedOrganisms = new Multiset<Organism>();
    }

    public int InitialHumidity, InitialSoilRichess, InitialTemperature;
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
        return new Multiset<Resource>(GetConsumedResources().Concat(GetRequiredResources())).MultisetDifference(GetProducedResources());
    }

    public Multiset<Resource> GetAvailableResources()
    {
        return GetProducedResources().MultisetDifference(new Multiset<Resource>(GetConsumedResources()));
    }

    public Multiset<Resource> GetSuperfluousResources()
    {
        return GetProducedResources().MultisetDifference(new Multiset<Resource>(GetConsumedResources().Concat(GetRequiredResources())));
    }

    public Multiset<Organism> GetUnsupportedOrganisms()
    {
        Multiset<Resource> missingResources = GetMissingResources();

        return new Multiset<Organism>(ContainedOrganisms.Where(
            (org) => missingResources.Intersect(org.ConsumedResources).Any()
            || missingResources.Intersect(org.RequiredResources).Any()
            || !org.CanSurviveInClimateOf(this)));
    }
}
