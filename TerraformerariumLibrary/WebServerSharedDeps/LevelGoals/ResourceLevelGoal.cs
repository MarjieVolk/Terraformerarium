using System;
using System.Collections.Generic;

public sealed class ResourceLevelGoal : LevelGoal
{
    public Resource Resource { get; }

    public ResourceLevelGoal(Resource resource, Operator @operator, int conditionValue)
        : base(@operator, conditionValue)
    {
        this.Resource = resource;
    }

    protected override string GoalTargetDisplayString()
    {
        return this.Resource.ToString();
    }

    protected override int GetValueFromEcosystem(Ecosystem finalEcosystem)
    {
        var resourceAmountsToEvaluate = finalEcosystem.GetAvailableResources();
        Dictionary<Resource, int> resourceCounts = resourceAmountsToEvaluate.AsDictionary();

        int valueFromEcosystem = resourceCounts.ContainsKey(this.Resource)
            ? resourceCounts[this.Resource]
            : 0;

        return valueFromEcosystem;
    }
}