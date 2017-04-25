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

    public string DisplayString()
    {
        return DisplayString(this.Operator) + " " + this.ConditionValue + " " + this.GoalTargetDisplayString() + "s on planet";
    }

    protected abstract string GoalTargetDisplayString();

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