using System;

public sealed class EnvironmentLevelGoalEvaluator : LevelGoalEvaluator<EnvironmentLevelGoal>
{
    protected override int GetValueFromEcosystem(EnvironmentLevelGoal goal, Ecosystem finalEcosystem)
    {
        switch (goal.EnvironmentAttribute)
        {
            case EnvironmentAttribute.SoilRichness:
                return finalEcosystem.SoilRichness;
            case EnvironmentAttribute.Temperature:
                return finalEcosystem.Temperature;
            case EnvironmentAttribute.Humidity:
                return finalEcosystem.Humidity;
            default:
                throw new ArgumentOutOfRangeException(nameof(goal.EnvironmentAttribute), goal.EnvironmentAttribute, $"Unknown {goal.EnvironmentAttribute.GetType().Name}");
        }
    }
}