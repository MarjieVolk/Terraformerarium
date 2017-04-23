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
    public static Multiset<EResource> GetProducedResources(this IEcosystem eco)
    {
        return new Multiset<EResource>(eco.ContainedOrganisms.SelectMany((org) => org.ProducedResources));
    }

    public static Multiset<EResource> GetConsumedResources(this IEcosystem eco)
    {
        return new Multiset<EResource>(eco.ContainedOrganisms.SelectMany((org) => org.ConsumedResources));
    }

    public static Multiset<EResource> GetRequiredResources(this IEcosystem eco)
    {
        return eco.ContainedOrganisms.Select((org) => org.RequiredResources).Aggregate(MultisetExtensions.MultisetMaxUnion);
    }

    public static Multiset<EResource> GetMissingResources(this IEcosystem eco)
    {
        return new Multiset<EResource>(eco.GetConsumedResources().Union(eco.GetRequiredResources())).MultisetDifference(eco.GetProducedResources());
    }

    public static Multiset<EResource> GetUnusedResources(this IEcosystem eco)
    {
        return eco.GetProducedResources().MultisetDifference(new Multiset<EResource>(eco.GetConsumedResources().Union(eco.GetRequiredResources())));
    }

    public static HashSet<IOrganism> GetUnsupportedOrganisms(this IEcosystem eco)
    {
        Multiset<EResource> missingResources = eco.GetMissingResources();

        return new HashSet<IOrganism>(eco.ContainedOrganisms.Where(
            (org) => missingResources.Intersect(org.ConsumedResources).Count() > 0
            || missingResources.Intersect(org.RequiredResources).Count() > 0
            || !org.CanSurviveInClimateOf(eco)));
    }
}
