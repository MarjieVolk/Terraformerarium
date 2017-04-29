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
        LevelLibrary.RegisterLevel("Level1", new Level()
        {
            InitialPlanet = NewEcosystem(0, 0, Normal),
            MaxOrganismsPerCapsule = 5,
            availableOrganisms = Organisms(EOrganism.COW, EOrganism.WHEAT, EOrganism.LETTUCE),
            LevelGoals = new List<LevelGoal>() {
                new ResourceLevelGoal(Resource.POOP, Operator.GreaterThanOrEqual, 2)
            }
        });

        LevelLibrary.RegisterLevel("Level2", new Level()
        {
            InitialPlanet = NewEcosystem(0, 0, High,
                EOrganism.BLUE_JAY,
                EOrganism.APPLE_TREE,
                EOrganism.HEN,
                EOrganism.LETTUCE,
                EOrganism.MOSQUITO),
            MaxOrganismsPerCapsule = 5,
            availableOrganisms = Organisms(EOrganism.COUGAR, EOrganism.APPLE_TREE, EOrganism.RABBIT, EOrganism.HEN, EOrganism.LETTUCE),
            LevelGoals = new List<LevelGoal>() {
                new ResourceLevelGoal(Resource.DISEASE, Operator.Equals, 0),
                new OrganismLevelGoal(EOrganism.APPLE_TREE, Operator.GreaterThanOrEqual, 1)
            }
        });

        LevelLibrary.RegisterLevel("Level3", new Level()
        {
            InitialPlanet = NewEcosystem(0, 0, High),
            MaxOrganismsPerCapsule = 5,
            availableOrganisms = Organisms(EOrganism.COW, EOrganism.FOX, EOrganism.COUGAR, EOrganism.HEN, EOrganism.GRASS, EOrganism.WHEAT),
            LevelGoals = new List<LevelGoal>() {
                new OrganismLevelGoal(EOrganism.COW, Operator.GreaterThanOrEqual, 2)
            }
        });

        LevelLibrary.RegisterLevel("Level4", new Level()
        {
            InitialPlanet = NewEcosystem(0, 0, High,
                EOrganism.LETTUCE, 
                EOrganism.HEN,
                EOrganism.SNAKE,
                EOrganism.ROCK),
            MaxOrganismsPerCapsule = 5,
            availableOrganisms = Organisms(
                EOrganism.BLUE_JAY, 
                EOrganism.HEN, 
                EOrganism.WHEAT, 
                EOrganism.APPLE_TREE, 
                EOrganism.MOSQUITO, 
                EOrganism.RABBIT,
                EOrganism.FOX,
                EOrganism.COUGAR,
                EOrganism.SQUIRREL),
            LevelGoals = new List<LevelGoal>() {
                new OrganismLevelGoal(EOrganism.HEN, Operator.Equals, 0),
                new OrganismLevelGoal(EOrganism.SNAKE, Operator.Equals, 1)
            }
        });

        // TODO
        LevelLibrary.RegisterLevel("Level5", new Level()
        {
            InitialPlanet = NewEcosystem(0, 0, High, EOrganism.SNAKE, EOrganism.ROCK, EOrganism.BLUE_JAY, EOrganism.APPLE_TREE, EOrganism.MOSQUITO),
            MaxOrganismsPerCapsule = 5,
            availableOrganisms = Organisms(EOrganism.COW, EOrganism.GRASS, EOrganism.WHEAT, EOrganism.FOX),
            LevelGoals = new List<LevelGoal>() {
                new ResourceLevelGoal(Resource.DISEASE, Operator.Equals, 0)
            }
        });
    }

    private static List<Organism> Organisms(params EOrganism[] organisms)
    {
        return organisms.Select(org => OrganismLibrary.GetOrganismFor(org)).OrderBy(org => org.Type.ToString()).ToList();
    }

    private static Ecosystem NewEcosystem(int initialHumidity, int initialSoilRichness, int initialTemperature, params EOrganism[] organisms)
    {
        return new Ecosystem(initialHumidity, initialSoilRichness, initialTemperature, Organisms(organisms).ToArray());
    }
}
