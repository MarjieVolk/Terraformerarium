[Evaluator(typeof(EnvironmentLevelGoalEvaluator))]
public sealed class EnvironmentLevelGoal : LevelGoal
{
    public EnvironmentAttribute EnvironmentAttribute { get; }

    public EnvironmentLevelGoal(EnvironmentAttribute environmentAttribute, Operator @operator, int conditionValue)
        : base(@operator, conditionValue)
    {
        this.EnvironmentAttribute = environmentAttribute;
    }
}