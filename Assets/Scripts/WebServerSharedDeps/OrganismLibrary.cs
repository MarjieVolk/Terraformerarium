using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class OrganismLibrary
{
    private static Dictionary<string, Organism> Library;

    public static Organism GetOrganismFor(string canonicalName)
    {
        Organism org;
        Library.TryGetValue(canonicalName, out org);

        return org;
    }

    public static void RegisterOrganism(string canonicalName, Organism org)
    {
        Library[canonicalName] = org;
    }
}
