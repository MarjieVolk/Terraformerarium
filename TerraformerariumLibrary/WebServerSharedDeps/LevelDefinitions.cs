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
            InitialPlanet = new Ecosystem(0, 0, 0, OrganismLibrary.GetOrganismFor(EOrganism.COW)),
            availableOrganisms = new List<Organism>() { OrganismLibrary.GetOrganismFor(EOrganism.COW) },
            LevelGoals = new List<LevelGoal>() { new ResourceLevelGoal(Resource.MEAT, Operator.GreaterThanOrEqual, 2)}
        });

        LevelLibrary.RegisterLevel("Level1", new Level()
        {
            InitialPlanet = NewEcosystem(0, 0, 0, EOrganism.COUGAR),
            availableOrganisms = Organisms(EOrganism.COW, EOrganism.SNAKE, EOrganism.FOX, EOrganism.HEN, EOrganism.APPLE_TREE, EOrganism.MOSQUITO, EOrganism.BLUE_JAY, EOrganism.GRASS).ToList(),
            LevelGoals = new List<LevelGoal>() {
                new ResourceLevelGoal(Resource.POOP, Operator.Equals, 0)
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
