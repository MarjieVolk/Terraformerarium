using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.WebServerSharedDeps;

public static class OrganismDefinitions
{
    private const int MinVeryLow = -7;
    private const int MinLow = -4;
    private const int MinNormal = -1;
    private const int MinHigh = 2;
    private const int MinVeryHigh = 5;
    private const int MaxVeryLow = -5;
    private const int MaxLow = -2;
    private const int MaxNormal = 1;
    private const int MaxHigh = 4;
    private const int MaxVeryHigh = 7;

    public static void Populate()
    {
        OrganismLibrary.RegisterOrganism(EOrganism.COW, new Organism()
        {
            MinimumHumidity = MinLow,
            MaximumHumidity = MaxHigh,
            HumidityMod = 0,
            MinimumTemperature = MinLow,
            MaximumTemperature = MaxHigh,
            TemperatureMod = 2,
            MinimumSoilRichness = MinVeryLow,
            MaximumSoilRichness = MaxVeryHigh,
            SoilRichnessMod = 3,
            RequiredResources = new Multiset<Resource>(Resource.GRASS),
            ConsumedResources = new Multiset<Resource>(Resource.GRASS),
            ProducedResources = new Multiset<Resource>(Resource.MEAT, Resource.POOP)
        });

        OrganismLibrary.RegisterOrganism(EOrganism.GRASS, new Organism()
        {
            MinimumHumidity = MinLow,
            MaximumHumidity = MaxVeryHigh,
            HumidityMod = 0,
            MinimumTemperature = MinLow,
            MaximumTemperature = MaxHigh,
            TemperatureMod = -1,
            MinimumSoilRichness = MinLow,
            MaximumSoilRichness = MaxVeryHigh,
            SoilRichnessMod = -1,
            RequiredResources = new Multiset<Resource>(),
            ConsumedResources = new Multiset<Resource>(),
            ProducedResources = new Multiset<Resource>(Resource.GRASS)
        });

        OrganismLibrary.RegisterOrganism(EOrganism.MOSQUITO, new Organism()
        {
            MinimumHumidity = MinNormal,
            MaximumHumidity = MaxVeryHigh,
            HumidityMod = 0,
            MinimumTemperature = MinNormal,
            MaximumTemperature = MaxVeryHigh,
            TemperatureMod = 0,
            MinimumSoilRichness = MinVeryLow,
            MaximumSoilRichness = MaxVeryHigh,
            SoilRichnessMod = 0,
            RequiredResources = new Multiset<Resource>(Resource.MEAT),
            ConsumedResources = new Multiset<Resource>(),
            ProducedResources = new Multiset<Resource>(Resource.BUGS, Resource.DISEASE)
        });

        OrganismLibrary.RegisterOrganism(EOrganism.BLUE_JAY, new Organism()
        {
            MinimumHumidity = MinLow,
            MaximumHumidity = MaxHigh,
            HumidityMod = 0,
            MinimumTemperature = MinNormal,
            MaximumTemperature = MaxHigh,
            TemperatureMod = 0,
            MinimumSoilRichness = MinVeryLow,
            MaximumSoilRichness = MaxVeryHigh,
            SoilRichnessMod = 1,
            RequiredResources = new Multiset<Resource>(Resource.SHADE),
            ConsumedResources = new Multiset<Resource>(Resource.BUGS),
            ProducedResources = new Multiset<Resource>()
        });

        OrganismLibrary.RegisterOrganism(EOrganism.APPLE_TREE, new Organism()
        {
            MinimumHumidity = MinHigh,
            MaximumHumidity = MaxHigh,
            HumidityMod = 0,
            MinimumTemperature = MinNormal,
            MaximumTemperature = MaxHigh,
            TemperatureMod = 0,
            MinimumSoilRichness = MinHigh,
            MaximumSoilRichness = MaxVeryHigh,
            SoilRichnessMod = 1,
            RequiredResources = new Multiset<Resource>(),
            ConsumedResources = new Multiset<Resource>(Resource.POOP),
            ProducedResources = new Multiset<Resource>(Resource.SHADE, Resource.FRUIT)
        });
    }
}
