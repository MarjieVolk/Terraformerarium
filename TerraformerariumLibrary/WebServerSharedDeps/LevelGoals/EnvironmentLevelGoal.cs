using System;

public sealed class EnvironmentLevelGoal : LevelGoal
{
    public EnvironmentAttribute EnvironmentAttribute { get; }

    public EnvironmentLevelGoal(EnvironmentAttribute environmentAttribute, Operator @operator, int conditionValue)
        : base(@operator, conditionValue)
    {
        this.EnvironmentAttribute = environmentAttribute;
    }

    protected override string GoalTargetDisplayString()
    {
        return EnvironmentAttribute.ToString();
    }

    protected override int GetValueFromEcosystem(Ecosystem finalEcosystem)
    {
        switch (this.EnvironmentAttribute)
        {
            case EnvironmentAttribute.SoilRichness:
                return finalEcosystem.SoilRichness;
            case EnvironmentAttribute.Temperature:
                return finalEcosystem.Temperature;
            case EnvironmentAttribute.Humidity:
                return finalEcosystem.Humidity;
            default:
                throw new ArgumentOutOfRangeException(
                    nameof(this.EnvironmentAttribute), 
                    this.EnvironmentAttribute, 
                    $"Unknown {this.EnvironmentAttribute.GetType().Name}");
        }
    }
}