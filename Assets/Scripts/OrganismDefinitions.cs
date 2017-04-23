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
        PopulateCow();
    }

    private static void PopulateCow()
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
            RequiredResources = new Multiset<EResource>(EResource.GRASS),
            ConsumedResources = new Multiset<EResource>(EResource.GRASS),
            ProducedResources = new Multiset<EResource>(EResource.MEAT, EResource.POOP)
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
            RequiredResources = new Multiset<EResource>(),
            ConsumedResources = new Multiset<EResource>(),
            ProducedResources = new Multiset<EResource>(EResource.GRASS)
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
            RequiredResources = new Multiset<EResource>(EResource.MEAT),
            ConsumedResources = new Multiset<EResource>(),
            ProducedResources = new Multiset<EResource>(EResource.BUGS, EResource.DISEASE)
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
            RequiredResources = new Multiset<EResource>(EResource.SHADE),
            ConsumedResources = new Multiset<EResource>(EResource.BUGS),
            ProducedResources = new Multiset<EResource>()
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
            RequiredResources = new Multiset<EResource>(),
            ConsumedResources = new Multiset<EResource>(EResource.POOP),
            ProducedResources = new Multiset<EResource>(EResource.SHADE, EResource.FRUIT)
        });
    }
}
