using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Organism : IOrganism
{
    public Multiset<EResource> ConsumedResources { get; set; }

    public Multiset<EResource> ProducedResources { get; set; }

    public Multiset<EResource> RequiredResources { get; set; }

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
