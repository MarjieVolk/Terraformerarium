using System;
using System.Collections.Generic;
using System.Linq;

public sealed class ResourceLevelGoalEvaluator : LevelGoalEvaluator<ResourceLevelGoal>
{
    protected override int GetValueFromEcosystem(ResourceLevelGoal goal, Ecosystem finalEcosystem)
    {
        var resourceAmountsToEvaluate = finalEcosystem.GetAvailableResources();
        Dictionary<Resource, int> resourceCounts = resourceAmountsToEvaluate.AsDictionary();

        int valueFromEcosystem = resourceCounts.ContainsKey(goal.Resource)
            ? resourceCounts[goal.Resource]
            : 0;

        return valueFromEcosystem;
    }
}