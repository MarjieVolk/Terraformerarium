using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public sealed class OrganismLevelGoalEvaluator : LevelGoalEvaluator<OrganismLevelGoal>
{
    protected override int GetValueFromEcosystem(OrganismLevelGoal goal, Ecosystem finalEcosystem)
    {
        return finalEcosystem.ContainedOrganisms.Where(o => o.Type == goal.Organism).Count();
    }
}
