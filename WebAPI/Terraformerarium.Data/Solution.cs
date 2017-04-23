using System;

namespace Terraformerarium.Data
{
    public class Solution
    {
        public int Id { get; set; }

        public int LevelId { get; set; }
        public Level Level { get; set; }

        public int Score { get; set; }

        public string SolutionData { get; set; }
    }
}