using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class LevelDefinitions
{
    public static void Populate()
    {
        PopulateRandomLevel();
    }

    private static void PopulateRandomLevel()
    {
        LevelLibrary.RegisterLevel("cowLevel", new Level()
        {
            InitialPlanet = new Ecosystem(0, 0, 0, OrganismLibrary.GetOrganismFor("cow")),
            availableOrganisms = new List<IOrganism>() { OrganismLibrary.GetOrganismFor("cow") },
            GoalEvaluator = (eco) => true
        });
    }
}
