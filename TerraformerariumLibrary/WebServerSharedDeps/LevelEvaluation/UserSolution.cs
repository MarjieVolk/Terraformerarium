using System;
using System.Collections.Generic;
using System.Linq;

public sealed class UserSolution
{
    private Level Level;
    private IList<Ecosystem> Capsules { get; }

    public UserSolution(string level, IList<Ecosystem> capsules)
    {
        this.Level = LevelLibrary.GetLevelFor(level);
        this.Capsules = capsules;
    }

    public UserSolution(string level, string solution) : this(level, ParseSolutionString(solution)) { }

    private static IList<Ecosystem> ParseSolutionString(string solution)
    {
        // TODO parse something here
        throw new NotImplementedException();
    }

    public Ecosystem GetFinalEcosystem()
    {
        Ecosystem planet = new Ecosystem(Level.InitialPlanet);
        foreach (Ecosystem capsule in Capsules)
        {
            // merge capsule ecosystem into planet
            planet.AddOrganisms(capsule.ContainedOrganisms);

            // simulate to convergence
            Multiset<Organism> unsupportedOrganisms = planet.GetUnsupportedOrganisms();
            while (unsupportedOrganisms.Count > 0)
            {
                planet.RemoveOrganisms(unsupportedOrganisms);
                unsupportedOrganisms = planet.GetUnsupportedOrganisms();
            }
        }

        return planet;
    }

    public bool IsLegal()
    {
        return Capsules.SelectMany(capsule => capsule.ContainedOrganisms).All(org => Level.availableOrganisms.Contains(org));
    }

    public bool MeetsGoalRequirements()
    {
        return LevelSolutionEvaluator.Create(Level.LevelGoals).EvaluateResult(this).IsValid;
    }

    public int GetScore()
    {
        return Capsules.Count;
    }
}