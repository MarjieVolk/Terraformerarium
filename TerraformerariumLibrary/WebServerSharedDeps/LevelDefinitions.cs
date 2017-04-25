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
        LevelLibrary.RegisterLevel("Level1", new Level()
        {
            InitialPlanet = NewEcosystem(0, 0, 0),
            MaxOrganismsPerCapsule = 5,
            availableOrganisms = Organisms(EOrganism.COW).ToList(),
            LevelGoals = new List<LevelGoal>() {
                new OrganismLevelGoal(EOrganism.COW, Operator.GreaterThanOrEqual, 1)
            }
        });
    }

    private static IEnumerable<Organism> Organisms(params EOrganism[] organisms)
    {
        return organisms.Select(org => OrganismLibrary.GetOrganismFor(org));
    }

    private static Ecosystem NewEcosystem(int initialHumidity, int initialSoilRichness, int initialTemperature, params EOrganism[] organisms)
    {
        return new Ecosystem(initialHumidity, initialSoilRichness, initialTemperature, Organisms(organisms).ToArray());
    }
}
