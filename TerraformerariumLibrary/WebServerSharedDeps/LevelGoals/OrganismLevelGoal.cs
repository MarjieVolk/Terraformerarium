using System.Linq;

public sealed class OrganismLevelGoal : LevelGoal
{
    public EOrganism Organism { get; }

    public OrganismLevelGoal(EOrganism organism, Operator @operator, int conditionValue)
    : base(@operator, conditionValue)
    {
        this.Organism = organism;
    }

    protected override string GoalTargetDisplayString()
    {
        return this.Organism.DisplayName();
    }

    protected override int GetValueFromEcosystem(Ecosystem finalEcosystem)
    {
        return finalEcosystem.ContainedOrganisms.Where(o => o.Type == this.Organism).Count();
    }
}
