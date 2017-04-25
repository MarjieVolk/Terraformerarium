using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[Evaluator(typeof(OrganismLevelGoalEvaluator))]
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
}
