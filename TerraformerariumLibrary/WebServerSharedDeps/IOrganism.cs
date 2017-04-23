using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.WebServerSharedDeps;

public interface IOrganism
{
    EOrganism Type { get; }

    Multiset<Resource> ProducedResources { get; }
    Multiset<Resource> ConsumedResources { get; }
    Multiset<Resource> RequiredResources { get; }

    int MinimumHumidity { get; }
    int MaximumHumidity { get; }
    int HumidityMod { get; }

    int MinimumSoilRichness { get; }
    int MaximumSoilRichness { get; }
    int SoilRichnessMod { get; }

    int MinimumTemperature { get; }
    int MaximumTemperature { get; }
    int TemperatureMod { get; }

}

public static class IOrganismExtensions
{
    public static bool CanSurviveInClimateOf(this IOrganism organism, IEcosystem ecosystem)
    {
        if (organism.MaximumHumidity < ecosystem.Humidity || organism.MinimumHumidity > ecosystem.Humidity)
        {
            return false;
        }

        if (organism.MaximumSoilRichness < ecosystem.SoilRichness || organism.MinimumSoilRichness > ecosystem.SoilRichness)
        {
            return false;
        }

        if (organism.MaximumTemperature < ecosystem.Temperature || organism.MinimumTemperature > ecosystem.Temperature)
        {
            return false;
        }

        return true;
    }
}
