using System;

public abstract class LevelGoalEvaluator<TGoalType>
    where TGoalType : LevelGoal
{
    protected bool IsSatisfied(TGoalType goal, int value)
    {
        switch (goal.Operator)
        {
            case Operator.Equals:
                return value == goal.ConditionValue;
            case Operator.GreaterThan:
                return value > goal.ConditionValue;
            case Operator.LessThan:
                return value < goal.ConditionValue;
            case Operator.GreaterThanOrEqual:
                return value >= goal.ConditionValue;
            case Operator.LessThanOrEqual:
                return value <= goal.ConditionValue;
            case Operator.NotEqual:
                return value != goal.ConditionValue;
            default:
                throw new ArgumentOutOfRangeException(nameof(goal.Operator), goal.Operator, $"Invalid {goal.Operator.GetType().Name}");
        }
    }
    
    public bool IsSatisfied(TGoalType goal, Ecosystem finalEcosystem)
    {
        int valueFromEcosystem = this.GetValueFromEcosystem(goal, finalEcosystem);
        return this.IsSatisfied(goal, valueFromEcosystem);
    }

    protected abstract int GetValueFromEcosystem(TGoalType goal, Ecosystem finalEcosystem);
}