using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IEcosystem
{
    HashSet<OrganismComponent> ContainedOrganisms { get; }
    Multiset<Resource> ProducedResources { get; }
    Multiset<Resource> ConsumedResources { get; }
    Multiset<Resource> RequiredResources { get; }
    int Humidity { get; }
    int SoilRichness { get; }
    int Temperature { get; }
}

