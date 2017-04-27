using System;
using System.Diagnostics;

/// <summary>
/// Amount(<see cref="Resource"/>) {<see cref="Operator"/>} <see cref="ConditionValue"/>
/// </summary>
/// <remarks>
/// Data type. Holds things, doesn't do things.
/// </remarks>
public abstract class LevelGoal
{
    public Operator Operator { get; }
    public int ConditionValue { get; }

    protected LevelGoal(Operator @operator, int conditionValue)
    {
        this.Operator = @operator;
        this.ConditionValue = conditionValue;
    }

    protected abstract string GoalTargetDisplayString();
    protected abstract int GetValueFromEcosystem(Ecosystem finalEcosystem);

    public string DisplayString()
    {
        return DisplayString(this.Operator) + " " + this.ConditionValue + " " + this.GoalTargetDisplayString() + "s on planet";
    }

    public bool IsSatisfied(Ecosystem finalEcosystem)
    {
        int valueFromEcosystem = this.GetValueFromEcosystem(finalEcosystem);
        return this.IsSatisfied(valueFromEcosystem);
    }

    protected bool IsSatisfied(int value)
    {
        switch (this.Operator)
        {
            case Operator.Equals:
                return value == this.ConditionValue;
            case Operator.GreaterThan:
                return value > this.ConditionValue;
            case Operator.LessThan:
                return value < this.ConditionValue;
            case Operator.GreaterThanOrEqual:
                return value >= this.ConditionValue;
            case Operator.LessThanOrEqual:
                return value <= this.ConditionValue;
            case Operator.NotEqual:
                return value != this.ConditionValue;
            default:
                throw new ArgumentOutOfRangeException(nameof(this.Operator), this.Operator, $"Invalid {this.Operator.GetType().Name}");
        }
    }

    private static string DisplayString(Operator op)
    {
        switch (op)
        {
            case Operator.Equals:
                return "Have exactly";
            case Operator.GreaterThan:
                return "Have more than";
            case Operator.LessThan:
                return "Have less than";
            case Operator.GreaterThanOrEqual:
                return "Have at least";
            case Operator.LessThanOrEqual:
                return "Have less than or equal to";
            case Operator.NotEqual:
                return "Have anything but";
            default:
                return "?";
        }
    }
}