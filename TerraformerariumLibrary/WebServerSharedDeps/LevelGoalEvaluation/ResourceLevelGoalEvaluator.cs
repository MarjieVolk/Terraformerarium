using System;
using System.Linq;

public sealed class ResourceLevelGoalEvaluator : LevelGoalEvaluator<ResourceLevelGoal>
{
    protected override int GetValueFromEcosystem(ResourceLevelGoal goal, Ecosystem finalEcosystem)
    {
        // TODO
        throw new NotImplementedException("I don't fully understand the Ecosystem API, so this logic is likely not correct");
        // TODO: Template logic
        var remainingResources = finalEcosystem.GetUnusedResources()
            .Union(finalEcosystem.GetProducedResources());
        // TODO: The API for MultiSet has me often converting it back to a Dictionary<T, int>, perhaps it should expose that
        // or I am not accostomed enough to how I should be using it.
        var resourceCounts = remainingResources
            .GroupBy(resource => resource)
            .ToDictionary(group => group.Key, group => group.Count());

        var valueFromEcosystem = resourceCounts.ContainsKey(goal.Resource)
            ? resourceCounts[goal.Resource]
            // TODO: Should this be null?
            : 0;
        return valueFromEcosystem;
    }
}