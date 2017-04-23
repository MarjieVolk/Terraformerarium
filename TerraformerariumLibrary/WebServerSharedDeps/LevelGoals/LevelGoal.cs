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
}