using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public sealed class LevelSolutionEvaluator : ISolutionEvaluator
{
    private readonly ICollection<LevelGoal> goals;

    private LevelSolutionEvaluator(IEnumerable<LevelGoal> goals)
    {
        this.goals = goals.ToList();
    }

    public static ISolutionEvaluator Create(IEnumerable<LevelGoal> goals)
    {
        return new LevelSolutionEvaluator(goals);
    }

    public static ISolutionEvaluator Create(params LevelGoal[] goals)
    {
        return new LevelSolutionEvaluator(goals);
    }

    public SolutionEvaluationResult EvaluateResult(UserSolution userSolution)
    {   
        IDictionary<LevelGoal, bool> goalResults = new Dictionary<LevelGoal, bool>();
        foreach (var goal in this.goals)
        {
            Ecosystem finalEcosystem = userSolution.GetFinalEcosystem();
            bool result = goal.IsSatisfied(finalEcosystem);
            goalResults[goal] = result;
        }

        bool allGoalsPassed = goalResults.Values.All(result => result == true);
        return new SolutionEvaluationResult(allGoalsPassed);
    }
}