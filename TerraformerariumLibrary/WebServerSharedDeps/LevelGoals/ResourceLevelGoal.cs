using System;

[Evaluator(typeof(ResourceLevelGoalEvaluator))]
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
}