using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class OrganismDefinitions
{
    public const int VeryLow = 0;
    public const int Low = 1;
    public const int Normal = 2;
    public const int High = 3;
    public const int VeryHigh = 4;

    public static void Populate()
    {
        OrganismLibrary.RegisterOrganism(new Organism()
        {
            Type = EOrganism.COW,
            MinimumHumidity = VeryLow,
            MaximumHumidity = VeryHigh,
            HumidityMod = 0,
            MinimumTemperature = Low,
            MaximumTemperature = High,
            TemperatureMod = 0,
            MinimumSoilRichness = VeryLow,
            MaximumSoilRichness = VeryHigh,
            SoilRichnessMod = 0,
            RequiredResources = new Multiset<Resource>(),
            ConsumedResources = new Multiset<Resource>(Resource.GRASS, Resource.GRASS),
            ProducedResources = new Multiset<Resource>(Resource.MEAT, Resource.POOP)
        });

        OrganismLibrary.RegisterOrganism(new Organism()
        {
            Type = EOrganism.GRASS,
            MinimumHumidity = VeryLow,
            MaximumHumidity = VeryHigh,
            HumidityMod = 0,
            MinimumTemperature = VeryLow,
            MaximumTemperature = Normal,
            TemperatureMod = 0,
            MinimumSoilRichness = VeryLow,
            MaximumSoilRichness = VeryHigh,
            SoilRichnessMod = 0,
            RequiredResources = new Multiset<Resource>(),
            ConsumedResources = new Multiset<Resource>(Resource.POOP),
            ProducedResources = new Multiset<Resource>(Resource.GRASS)
        });

        OrganismLibrary.RegisterOrganism(new Organism()
        {
            Type = EOrganism.WHEAT,
            MinimumHumidity = VeryLow,
            MaximumHumidity = VeryHigh,
            HumidityMod = 0,
            MinimumTemperature = High,
            MaximumTemperature = VeryHigh,
            TemperatureMod = 0,
            MinimumSoilRichness = VeryLow,
            MaximumSoilRichness = VeryHigh,
            SoilRichnessMod = 0,
            RequiredResources = new Multiset<Resource>(),
            ConsumedResources = new Multiset<Resource>(Resource.POOP),
            ProducedResources = new Multiset<Resource>(Resource.GRASS)
        });

        OrganismLibrary.RegisterOrganism(new Organism()
        {
            Type = EOrganism.LETTUCE,
            MinimumHumidity = VeryLow,
            MaximumHumidity = VeryHigh,
            HumidityMod = 0,
            MinimumTemperature = Low,
            MaximumTemperature = High,
            TemperatureMod = 0,
            MinimumSoilRichness = VeryLow,
            MaximumSoilRichness = VeryHigh,
            SoilRichnessMod = 0,
            RequiredResources = new Multiset<Resource>(Resource.POOP),
            ConsumedResources = new Multiset<Resource>(),
            ProducedResources = new Multiset<Resource>(Resource.GRASS, Resource.GRASS)
        });

        OrganismLibrary.RegisterOrganism(new Organism()
        {
            Type = EOrganism.MOSQUITO,
            MinimumHumidity = VeryLow,
            MaximumHumidity = VeryHigh,
            HumidityMod = 0,
            MinimumTemperature = Normal,
            MaximumTemperature = VeryHigh,
            TemperatureMod = 0,
            MinimumSoilRichness = VeryLow,
            MaximumSoilRichness = VeryHigh,
            SoilRichnessMod = 0,
            RequiredResources = new Multiset<Resource>(Resource.MEAT),
            ConsumedResources = new Multiset<Resource>(),
            ProducedResources = new Multiset<Resource>(Resource.BUGS, Resource.DISEASE)
        });

        OrganismLibrary.RegisterOrganism(new Organism()
        {
            Type = EOrganism.BLUE_JAY,
            MinimumHumidity = VeryLow,
            MaximumHumidity = VeryHigh,
            HumidityMod = 0,
            MinimumTemperature = High,
            MaximumTemperature = VeryHigh,
            TemperatureMod = 0,
            MinimumSoilRichness = VeryLow,
            MaximumSoilRichness = VeryHigh,
            SoilRichnessMod = 1,
            RequiredResources = new Multiset<Resource>(Resource.SHADE),
            ConsumedResources = new Multiset<Resource>(Resource.BUGS),
            ProducedResources = new Multiset<Resource>(Resource.EGGSES, Resource.POOP)
        });

        OrganismLibrary.RegisterOrganism(new Organism()
        {
            Type = EOrganism.APPLE_TREE,
            MinimumHumidity = VeryLow,
            MaximumHumidity = VeryHigh,
            HumidityMod = 0,
            MinimumTemperature = Low,
            MaximumTemperature = High,
            TemperatureMod = 0,
            MinimumSoilRichness = VeryLow,
            MaximumSoilRichness = VeryHigh,
            SoilRichnessMod = 1,
            RequiredResources = new Multiset<Resource>(),
            ConsumedResources = new Multiset<Resource>(Resource.POOP),
            ProducedResources = new Multiset<Resource>(Resource.SHADE, Resource.FRUIT, Resource.FRUIT, Resource.FRUIT)
        });

        OrganismLibrary.RegisterOrganism(new Organism()
        {
            Type = EOrganism.FOX,
            MinimumHumidity = VeryLow,
            MaximumHumidity = VeryHigh,
            HumidityMod = 0,
            MinimumTemperature = VeryLow,
            MaximumTemperature = Low,
            TemperatureMod = 0,
            MinimumSoilRichness = VeryLow,
            MaximumSoilRichness = VeryHigh,
            SoilRichnessMod = 0,
            RequiredResources = new Multiset<Resource>(),
            ConsumedResources = new Multiset<Resource>(Resource.MEAT),
            ProducedResources = new Multiset<Resource>(Resource.POOP)
        });

        OrganismLibrary.RegisterOrganism(new Organism()
        {
            Type = EOrganism.COUGAR,
            MinimumHumidity = VeryLow,
            MaximumHumidity = VeryHigh,
            HumidityMod = 0,
            MinimumTemperature = Low,
            MaximumTemperature = High,
            TemperatureMod = 0,
            MinimumSoilRichness = VeryLow,
            MaximumSoilRichness = VeryHigh,
            SoilRichnessMod = 0,
            RequiredResources = new Multiset<Resource>(Resource.SHADE),
            ConsumedResources = new Multiset<Resource>(Resource.MEAT, Resource.MEAT),
            ProducedResources = new Multiset<Resource>(Resource.POOP)
        });

        OrganismLibrary.RegisterOrganism(new Organism()
        {
            Type = EOrganism.SNAKE,
            MinimumHumidity = VeryLow,
            MaximumHumidity = VeryHigh,
            HumidityMod = 0,
            MinimumTemperature = High,
            MaximumTemperature = High,
            TemperatureMod = 0,
            MinimumSoilRichness = VeryLow,
            MaximumSoilRichness = VeryHigh,
            SoilRichnessMod = 0,
            RequiredResources = new Multiset<Resource>(Resource.ROCK),
            ConsumedResources = new Multiset<Resource>(Resource.EGGSES),
            ProducedResources = new Multiset<Resource>(Resource.DISEASE)
        });

        OrganismLibrary.RegisterOrganism(new Organism()
        {
            Type = EOrganism.HEN,
            MinimumHumidity = VeryLow,
            MaximumHumidity = VeryHigh,
            HumidityMod = 0,
            MinimumTemperature = Low,
            MaximumTemperature = High,
            TemperatureMod = 0,
            MinimumSoilRichness = VeryLow,
            MaximumSoilRichness = VeryHigh,
            SoilRichnessMod = 0,
            RequiredResources = new Multiset<Resource>(Resource.GRASS),
            ConsumedResources = new Multiset<Resource>(),
            ProducedResources = new Multiset<Resource>(Resource.EGGSES, Resource.POOP, Resource.MEAT)
        });

        OrganismLibrary.RegisterOrganism(new Organism()
        {
            Type = EOrganism.ROCK,
            MinimumHumidity = VeryLow,
            MaximumHumidity = VeryHigh,
            HumidityMod = 0,
            MinimumTemperature = VeryLow,
            MaximumTemperature = VeryHigh,
            TemperatureMod = 0,
            MinimumSoilRichness = VeryLow,
            MaximumSoilRichness = VeryHigh,
            SoilRichnessMod = 0,
            RequiredResources = new Multiset<Resource>(),
            ConsumedResources = new Multiset<Resource>(),
            ProducedResources = new Multiset<Resource>(Resource.ROCK)
        });

        OrganismLibrary.RegisterOrganism(new Organism()
        {
            Type = EOrganism.RABBIT,
            MinimumHumidity = VeryLow,
            MaximumHumidity = VeryHigh,
            HumidityMod = 0,
            MinimumTemperature = VeryLow,
            MaximumTemperature = Normal,
            TemperatureMod = 0,
            MinimumSoilRichness = VeryLow,
            MaximumSoilRichness = VeryHigh,
            SoilRichnessMod = 0,
            RequiredResources = new Multiset<Resource>(),
            ConsumedResources = new Multiset<Resource>(Resource.FRUIT),
            ProducedResources = new Multiset<Resource>(Resource.MEAT)
        });

        OrganismLibrary.RegisterOrganism(new Organism()
        {
            Type = EOrganism.SQUIRREL,
            MinimumHumidity = VeryLow,
            MaximumHumidity = VeryHigh,
            HumidityMod = 0,
            MinimumTemperature = Low,
            MaximumTemperature = High,
            TemperatureMod = 0,
            MinimumSoilRichness = VeryLow,
            MaximumSoilRichness = VeryHigh,
            SoilRichnessMod = 0,
            RequiredResources = new Multiset<Resource>(Resource.FRUIT),
            ConsumedResources = new Multiset<Resource>(),
            ProducedResources = new Multiset<Resource>(Resource.POOP)
        });

        OrganismLibrary.RegisterOrganism(new Organism()
        {
            Type = EOrganism.OAK_TREE,
            MinimumHumidity = VeryLow,
            MaximumHumidity = VeryHigh,
            HumidityMod = 0,
            MinimumTemperature = Low,
            MaximumTemperature = Low,
            TemperatureMod = 0,
            MinimumSoilRichness = VeryLow,
            MaximumSoilRichness = VeryHigh,
            SoilRichnessMod = 0,
            RequiredResources = new Multiset<Resource>(),
            ConsumedResources = new Multiset<Resource>(Resource.POOP),
            ProducedResources = new Multiset<Resource>(Resource.SHADE, Resource.GRASS, Resource.GRASS)
        });
    }
}
