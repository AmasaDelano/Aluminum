using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Aluminum.Models
{
    public class RoomOfRequirement : DbContext
    {
        public RoomOfRequirement()
            : base("Name=RoomOfRequirement")
        {
            Database.SetInitializer<RoomOfRequirement>(null);
        }

        public DbSet<Costume> Costumes
        {
            get { return Set<Costume>(); }
        }

        public DbSet<CostumeQuestion> CostumeQuestions
        {
            get { return Set<CostumeQuestion>(); }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Tables
            modelBuilder.Entity<Costume>();
            modelBuilder.Entity<CostumeQuestion>();

            // Conventions
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Properties<string>().Configure(e => e.IsRequired());
        }
    }
}