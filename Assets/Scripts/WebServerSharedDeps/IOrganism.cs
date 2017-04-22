using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IOrganism
{
    Multiset<Resource> ProducedResources { get; }
    Multiset<Resource> ConsumedResources { get; }
    Multiset<Resource> RequiredResources { get; }

    int MinimumHumidity { get; }
    int MaximumHumidity { get; }

    int MinimumSoilRichness { get; }
    int MaximumSoilRichness { get; }

    int MinimumTemperature { get; }
    int MaximumTemperature { get; }
}

