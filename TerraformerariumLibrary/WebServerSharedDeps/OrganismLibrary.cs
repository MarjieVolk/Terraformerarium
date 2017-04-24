using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class OrganismLibrary
{
    private static readonly Dictionary<EOrganism, Organism> Library = new Dictionary<EOrganism, Organism>();

    public static Organism GetOrganismFor(EOrganism type)
    {
        Organism org;
        Library.TryGetValue(type, out org);

        return org;
    }

    public static void RegisterOrganism(Organism org)
    {
        Library[org.Type] = org;
    }
}
