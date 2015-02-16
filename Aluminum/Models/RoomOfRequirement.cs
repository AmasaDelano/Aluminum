using System.ComponentModel.DataAnnotations.Schema;
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

        public DbSet<CostumeSuggestion> CostumeSuggestions
        {
            get { return Set<CostumeSuggestion>(); }
        }

        public DbSet<User> Users
        {
            get { return Set<User>(); }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Tables
            modelBuilder.Entity<Costume>();
            modelBuilder.Entity<CostumeQuestion>();
            modelBuilder.Entity<CostumeSuggestion>();
            modelBuilder.Entity<User>();

            // Conventions
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Properties<string>().Configure(e => e.IsRequired());
            modelBuilder.Properties().Where(e => e.SetMethod.IsPrivate)
                .Configure(e => e.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed));
        }
    }
}