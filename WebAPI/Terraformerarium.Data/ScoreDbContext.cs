using System.Collections;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Terraformerarium.Data
{
    public class ScoreDbContext : DbContext
    {
        public ScoreDbContext() : base("ScoreDbContext")
        {
        }

        public DbSet<Level> Levels { get; set; }
        public DbSet<Solution> Solutions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
