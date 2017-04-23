using System;

[AttributeUsage(AttributeTargets.Class)]
internal sealed class Evaluator : Attribute
{
    public Evaluator(Type evaluatorType)
    {
        // Runtime evaluation gross, but could easily introduce a test to validate ahead of time.
        if (!evaluatorType.BaseType.IsGenericType || evaluatorType.BaseType.GetGenericTypeDefinition() != typeof(LevelGoalEvaluator<>))
        {
            throw new ArgumentOutOfRangeException(nameof(evaluatorType), evaluatorType, $"Must be a child of {typeof(LevelGoalEvaluator<>).Name}");
        }
        if (evaluatorType.GetConstructor(new Type[] { }) == null)
        {
            throw new ArgumentException("Type must have a parameterless constructor", nameof(evaluatorType));
        }

        this.EvaluatorType = evaluatorType;
    }

    public Type EvaluatorType { get; }
}