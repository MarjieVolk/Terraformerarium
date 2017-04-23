using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Ecosystem : IEcosystem
{
    public HashSet<IOrganism> ContainedOrganisms { get; set; }

    public Ecosystem(int initialHumidity, int initialSoilRichness, int initialTemperature, params IOrganism[] organisms)
    {
        InitialHumidity = initialHumidity;
        InitialSoilRichess = initialSoilRichness;
        InitialTemperature = initialTemperature;
        ContainedOrganisms = new HashSet<IOrganism>(organisms);
    }

    private int InitialHumidity, InitialSoilRichess, InitialTemperature;

    public int Humidity {
        get
        {
            return InitialHumidity + ContainedOrganisms.Select((org) => org.HumidityMod).Sum();
        }
    }

    public int SoilRichness
    {
        get
        {
            return InitialSoilRichess + ContainedOrganisms.Select((org) => org.SoilRichnessMod).Sum();
        }
    }

    public int Temperature
    {
        get
        {
            return InitialTemperature + ContainedOrganisms.Select((org) => org.TemperatureMod).Sum();
        }
    }
}
