using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        OrganismLibrary.RegisterOrganism(new Organism()
        {
            Type = EOrganism.COW,
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

        OrganismLibrary.RegisterOrganism(new Organism()
        {
            Type = EOrganism.GRASS,
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

        OrganismLibrary.RegisterOrganism(new Organism()
        {
            Type = EOrganism.MOSQUITO,
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

        OrganismLibrary.RegisterOrganism(new Organism()
        {
            Type = EOrganism.BLUE_JAY,
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

        OrganismLibrary.RegisterOrganism(new Organism()
        {
            Type = EOrganism.APPLE_TREE,
            MinimumHumidity = MinHigh,
            MaximumHumidity = MaxHigh,
            HumidityMod = 0,
            MinimumTemperature = MinNormal,
            MaximumTemperature = MaxHigh,
            TemperatureMod = -3,
            MinimumSoilRichness = MinHigh,
            MaximumSoilRichness = MaxVeryHigh,
            SoilRichnessMod = 1,
            RequiredResources = new Multiset<Resource>(),
            ConsumedResources = new Multiset<Resource>(Resource.POOP),
            ProducedResources = new Multiset<Resource>(Resource.SHADE, Resource.FRUIT)
        });

        OrganismLibrary.RegisterOrganism(new Organism()
        {
            Type = EOrganism.FOX,
            MinimumHumidity = MinVeryLow,
            MaximumHumidity = MaxVeryHigh,
            HumidityMod = 0,
            MinimumTemperature = MinVeryLow,
            MaximumTemperature = MaxLow,
            TemperatureMod = 1,
            MinimumSoilRichness = MinVeryLow,
            MaximumSoilRichness = MaxVeryHigh,
            SoilRichnessMod = 0,
            RequiredResources = new Multiset<Resource>(),
            ConsumedResources = new Multiset<Resource>(Resource.MEAT),
            ProducedResources = new Multiset<Resource>(Resource.MEAT)
        });

        OrganismLibrary.RegisterOrganism(new Organism()
        {
            Type = EOrganism.COUGAR,
            MinimumHumidity = MinVeryLow,
            MaximumHumidity = MaxVeryHigh,
            HumidityMod = 0,
            MinimumTemperature = MinVeryLow,
            MaximumTemperature = MaxNormal,
            TemperatureMod = 1,
            MinimumSoilRichness = MinVeryLow,
            MaximumSoilRichness = MaxVeryHigh,
            SoilRichnessMod = 0,
            RequiredResources = new Multiset<Resource>(Resource.SHADE, Resource.ROCK),
            ConsumedResources = new Multiset<Resource>(Resource.MEAT, Resource.MEAT),
            ProducedResources = new Multiset<Resource>(Resource.POOP)
        });
    }
}
