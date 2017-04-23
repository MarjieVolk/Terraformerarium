using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public static class OrganismDefinitions
{
    public static void Populate()
    {
        PopulateCow();
    }

    private static void PopulateCow()
    {
        OrganismLibrary.RegisterOrganism("cow", new Organism()
        {
            MinimumHumidity = 0,
            MaximumHumidity = 0,
            HumidityMod = 0,
            MinimumTemperature = 0,
            MaximumTemperature = 0,
            TemperatureMod = 1,
            MinimumSoilRichness = 0,
            MaximumSoilRichness = 0,
            SoilRichnessMod = 1,
            RequiredResources = new Multiset<Resource>(Resource.GRASS),
            ConsumedResources = new Multiset<Resource>(Resource.GRASS),
            ProducedResources = new Multiset<Resource>(Resource.MEAT, Resource.POOP)
        });
    }
}
