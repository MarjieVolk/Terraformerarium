using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.WebServerSharedDeps;

public class Organism : IOrganism
{
    public EOrganism Type { get; set; }

    public Multiset<Resource> ConsumedResources { get; set; }

    public Multiset<Resource> ProducedResources { get; set; }

    public Multiset<Resource> RequiredResources { get; set; }

    public int MinimumHumidity { get; set; }

    public int MaximumHumidity { get; set; }

    public int HumidityMod { get; set; }

    public int MinimumSoilRichness { get; set; }

    public int MaximumSoilRichness { get; set; }

    public int SoilRichnessMod { get; set; }

    public int MinimumTemperature { get; set; }

    public int MaximumTemperature { get; set; }

    public int TemperatureMod { get; set; }
}
