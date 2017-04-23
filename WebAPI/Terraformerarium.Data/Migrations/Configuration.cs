using System.Collections.Generic;

namespace Terraformerarium.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Terraformerarium.Data.ScoreDbContext>
    {
        private const int NUM_LEVELS = 10;
        private const int NUM_SCORES = 15;
        private const int MAX_SCORE = 10;

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ScoreDbContext context)
        {
            context.Database.Connection.Open();
            var cmd = context.Database.Connection.CreateCommand();
            cmd.CommandText = "TRUNCATE TABLE dbo.Solution\nDELETE FROM dbo.Level";
            cmd.ExecuteNonQuery();

            var r = new Random();
            
            for (var i = 0; i < NUM_LEVELS; ++i)
            {
                var level = context.Levels.Add(new Level {LevelKey = "Level" + i});
                level.Solutions = new List<Solution>();

                for (var n = 0; n < NUM_SCORES; ++n)
                {
                    level.Solutions.Add(new Solution
                    {
                        Level = level,
                        Score = r.Next(1, MAX_SCORE)
                    });
                }
            }

            context.SaveChanges();

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
