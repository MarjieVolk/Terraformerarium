using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IEcosystem
{
    HashSet<IOrganism> ContainedOrganisms { get; }
    int Humidity { get; }
    int SoilRichness { get; }
    int Temperature { get; }
}

public static class IEcosystemExtensions
{
    public static Multiset<Resource> GetProducedResources(this IEcosystem eco)
    {
        return new Multiset<Resource>(eco.ContainedOrganisms.SelectMany((org) => org.ProducedResources));
    }

    public static Multiset<Resource> GetConsumedResources(this IEcosystem eco)
    {
        return new Multiset<Resource>(eco.ContainedOrganisms.SelectMany((org) => org.ConsumedResources));
    }

    public static Multiset<Resource> GetRequiredResources(this IEcosystem eco)
    {
        return eco.ContainedOrganisms.Select((org) => org.RequiredResources).Aggregate(MultisetExtensions.MultisetMaxUnion);
    }

    public static Multiset<Resource> GetMissingResources(this IEcosystem eco)
    {
        return new Multiset<Resource>(eco.GetConsumedResources().Union(eco.GetRequiredResources())).MultisetDifference(eco.GetProducedResources());
    }

    public static Multiset<Resource> GetUnusedResources(this IEcosystem eco)
    {
        return eco.GetProducedResources().MultisetDifference(new Multiset<Resource>(eco.GetConsumedResources().Union(eco.GetRequiredResources())));
    }

    public static HashSet<IOrganism> GetUnsupportedOrganisms(this IEcosystem eco)
    {
        Multiset<Resource> missingResources = eco.GetMissingResources();

        return new HashSet<IOrganism>(eco.ContainedOrganisms.Where(
            (org) => missingResources.Intersect(org.ConsumedResources).Count() > 0
            || missingResources.Intersect(org.RequiredResources).Count() > 0
            || !org.CanSurviveInClimateOf(eco)));
    }
}
