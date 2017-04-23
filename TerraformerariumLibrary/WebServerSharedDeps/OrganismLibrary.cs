using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.WebServerSharedDeps;

public static class OrganismLibrary
{
    private static Dictionary<EOrganism, Organism> Library = new Dictionary<EOrganism, Organism>();

    public static Organism GetOrganismFor(EOrganism type)
    {
        Organism org;
        Library.TryGetValue(type, out org);

        return org;
    }

    public static void RegisterOrganism(EOrganism type, Organism org)
    {
        Library[type] = org;
    }
}
