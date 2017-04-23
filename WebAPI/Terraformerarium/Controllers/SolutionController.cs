using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Terraformerarium.Data;
using Terraformerarium.Models;

namespace Terraformerarium.Controllers
{
    public class SolutionController : ApiController
    {
        [Route("api/solution")]
        [HttpPost]
        public async Task<int> SubmitSolution(SubmitSolutionModel model)
        {
            var score = SolutionEvaluator.Evaluate(model.SolutionData);

            using (var dbc = new ScoreDbContext())
            {
                var level = dbc.Levels.FirstOrDefault(l => l.LevelKey == model.LevelKey);

                if (level == null)
                {
                    var msg =
                        new HttpResponseMessage(HttpStatusCode.BadRequest)
                        {
                            ReasonPhrase = "Invalid level id"
                        };
                    throw new HttpResponseException(msg);
                }

                var solution = dbc.Solutions.Add(new Solution());
                solution.Level = level;
                solution.SolutionData = model.SolutionData;
                solution.Score = score;

                await dbc.SaveChangesAsync();           
            }
            return score;
        }

        /// <summary>
        /// Calculates the count of each score.  
        /// </summary>
        /// <param name="levelKey"></param>
        /// <returns></returns>
        [Route("api/solution/summary")]
        [HttpGet]
        public async Task<ScoreSummaryModel> FetchHistogram(String levelKey)
        {
            using (var dbc = new ScoreDbContext())
            {
                var summary = await dbc.Solutions.Where(s => s.Level.LevelKey == levelKey)
                    .GroupBy(s => s.Score)
                    .Select(g => new
                    {
                        Score = g.Key,
                        Count = g.Count()
                    })
                    .ToListAsync();

                if (summary.Count == 0)
                {
                    var msg =
                        new HttpResponseMessage(HttpStatusCode.BadRequest)
                        {
                            ReasonPhrase = "Invalid level id or no scores for that level have been submitted"
                        };
                    throw new HttpResponseException(msg);
                }

                int[] counts = new int[summary.Max(r => r.Score) + 1];
                foreach (var r in summary)
                {
                    counts[r.Score] = r.Count;
                }

                return new ScoreSummaryModel {ScoreCounts = counts};
            }
        }

        internal class SolutionEvaluator
        {
            private static readonly Random Random = new Random();

            public static int Evaluate(string modelSolutionData)
            {
                return Random.Next(1, 10);
            }
        }
    }
}
