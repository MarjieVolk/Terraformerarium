using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class LevelDefinitions
{
    public const int VeryLow = OrganismDefinitions.VeryLow;
    public const int Low = OrganismDefinitions.Low;
    public const int Normal = OrganismDefinitions.Normal;
    public const int High = OrganismDefinitions.High;
    public const int VeryHigh = OrganismDefinitions.VeryHigh;

    public static void Populate()
    {
        PopulateRandomLevel();
    }

    private static void PopulateRandomLevel()
    {
        LevelLibrary.RegisterLevel("Level1", new Level()
        {
            InitialPlanet = NewEcosystem(0, 0, Normal),
            MaxOrganismsPerCapsule = 5,
            availableOrganisms = Organisms(EOrganism.COW, EOrganism.LETTUCE, EOrganism.WHEAT).ToList(),
            LevelGoals = new List<LevelGoal>() {
                new ResourceLevelGoal(Resource.POOP, Operator.GreaterThanOrEqual, 2)
            }
        });

        LevelLibrary.RegisterLevel("Level2", new Level()
        {
            InitialPlanet = NewEcosystem(0, 0, High),
            MaxOrganismsPerCapsule = 5,
            availableOrganisms = Organisms(EOrganism.COW, EOrganism.GRASS, EOrganism.WHEAT, EOrganism.FOX).ToList(),
            LevelGoals = new List<LevelGoal>() {
                new OrganismLevelGoal(EOrganism.COW, Operator.GreaterThanOrEqual, 2)
            }
        });

        LevelLibrary.RegisterLevel("Level3", new Level()
        {
            InitialPlanet = NewEcosystem(0, 0, High, EOrganism.SNAKE, EOrganism.ROCK, EOrganism.BLUE_JAY, EOrganism.APPLE_TREE, EOrganism.MOSQUITO),
            MaxOrganismsPerCapsule = 5,
            availableOrganisms = Organisms(EOrganism.COW, EOrganism.GRASS, EOrganism.WHEAT, EOrganism.FOX).ToList(),
            LevelGoals = new List<LevelGoal>() {
                new ResourceLevelGoal(Resource.DISEASE, Operator.Equals, 0)
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
