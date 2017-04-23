/// <summary>
/// Encapsulates the solution result
/// </summary>
/// <remarks>
/// In case we add more than just IsValid later, better to have it piped through (don't YAGNI me!)
/// </remarks>
public sealed class SolutionEvaluationResult
{
    public bool IsValid { get; }

    public SolutionEvaluationResult(bool isValid)
    {
        this.IsValid = isValid;
    }
}