﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class OrganismDefinitions
{
    public const int MinVeryLow = -7;
    public const int MinLow = -4;
    public const int MinNormal = -1;
    public const int MinHigh = 2;
    public const int MinVeryHigh = 5;
    public const int MaxVeryLow = -5;
    public const int MaxLow = -2;
    public const int MaxNormal = 1;
    public const int MaxHigh = 4;
    public const int MaxVeryHigh = 7;

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
            TemperatureMod = 1,
            MinimumSoilRichness = MinVeryLow,
            MaximumSoilRichness = MaxVeryHigh,
            SoilRichnessMod = 2,
            RequiredResources = new Multiset<Resource>(Resource.GRASS),
            ConsumedResources = new Multiset<Resource>(Resource.GRASS),
            ProducedResources = new Multiset<Resource>(Resource.MEAT, Resource.POOP)
        });

        OrganismLibrary.RegisterOrganism(new Organism()
        {
            Type = EOrganism.GRASS,
            MinimumHumidity = MinVeryLow,
            MaximumHumidity = MaxVeryHigh,
            HumidityMod = 0,
            MinimumTemperature = MinVeryLow,
            MaximumTemperature = MaxNormal,
            TemperatureMod = 0,
            MinimumSoilRichness = MinLow,
            MaximumSoilRichness = MaxVeryHigh,
            SoilRichnessMod = 0,
            RequiredResources = new Multiset<Resource>(),
            ConsumedResources = new Multiset<Resource>(Resource.POOP),
            ProducedResources = new Multiset<Resource>(Resource.GRASS)
        });

        OrganismLibrary.RegisterOrganism(new Organism()
        {
            Type = EOrganism.WHEAT,
            MinimumHumidity = MinVeryLow,
            MaximumHumidity = MaxVeryHigh,
            HumidityMod = 0,
            MinimumTemperature = MinHigh,
            MaximumTemperature = MaxVeryHigh,
            TemperatureMod = 0,
            MinimumSoilRichness = MinNormal,
            MaximumSoilRichness = MaxVeryHigh,
            SoilRichnessMod = 0,
            RequiredResources = new Multiset<Resource>(),
            ConsumedResources = new Multiset<Resource>(Resource.POOP),
            ProducedResources = new Multiset<Resource>(Resource.GRASS)
        });

        OrganismLibrary.RegisterOrganism(new Organism()
        {
            Type = EOrganism.LETTUCE,
            MinimumHumidity = MinVeryLow,
            MaximumHumidity = MaxVeryHigh,
            HumidityMod = 0,
            MinimumTemperature = MinLow,
            MaximumTemperature = MaxHigh,
            TemperatureMod = -1,
            MinimumSoilRichness = MinNormal,
            MaximumSoilRichness = MaxVeryHigh,
            SoilRichnessMod = -1,
            RequiredResources = new Multiset<Resource>(Resource.POOP),
            ConsumedResources = new Multiset<Resource>(),
            ProducedResources = new Multiset<Resource>(Resource.GRASS, Resource.GRASS)
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
            ProducedResources = new Multiset<Resource>(Resource.POOP)
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

        OrganismLibrary.RegisterOrganism(new Organism()
        {
            Type = EOrganism.SNAKE,
            MinimumHumidity = MinVeryLow,
            MaximumHumidity = MaxNormal,
            HumidityMod = 0,
            MinimumTemperature = MinHigh,
            MaximumTemperature = MaxVeryHigh,
            TemperatureMod = 1,
            MinimumSoilRichness = MinVeryLow,
            MaximumSoilRichness = MaxVeryHigh,
            SoilRichnessMod = 0,
            RequiredResources = new Multiset<Resource>(Resource.ROCK),
            ConsumedResources = new Multiset<Resource>(Resource.EGGSES),
            ProducedResources = new Multiset<Resource>(Resource.DISEASE)
        });

        OrganismLibrary.RegisterOrganism(new Organism()
        {
            Type = EOrganism.HEN,
            MinimumHumidity = MinVeryLow,
            MaximumHumidity = MaxVeryHigh,
            HumidityMod = 0,
            MinimumTemperature = MinLow,
            MaximumTemperature = MaxHigh,
            TemperatureMod = 1,
            MinimumSoilRichness = MinVeryLow,
            MaximumSoilRichness = MaxVeryHigh,
            SoilRichnessMod = 0,
            RequiredResources = new Multiset<Resource>(Resource.GRASS),
            ConsumedResources = new Multiset<Resource>(Resource.GRAINS),
            ProducedResources = new Multiset<Resource>(Resource.EGGSES)
        });

        OrganismLibrary.RegisterOrganism(new Organism()
        {
            Type = EOrganism.ROCK,
            MinimumHumidity = MinVeryLow,
            MaximumHumidity = MaxVeryHigh,
            HumidityMod = 0,
            MinimumTemperature = MinVeryLow,
            MaximumTemperature = MaxVeryHigh,
            TemperatureMod = 1,
            MinimumSoilRichness = MinVeryLow,
            MaximumSoilRichness = MaxVeryHigh,
            SoilRichnessMod = 0,
            RequiredResources = new Multiset<Resource>(),
            ConsumedResources = new Multiset<Resource>(),
            ProducedResources = new Multiset<Resource>(Resource.ROCK)
        });
    }
}
