using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;

namespace Aluminum.Data
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

        protected override DbEntityValidationResult ValidateEntity(
            DbEntityEntry entityEntry,
            IDictionary<object, object> items)
        {
            // Validate the entity
            var result = base.ValidateEntity(entityEntry, items);

            // Ignore errors on properties that are not being modified
            if (result.ValidationErrors.Count > 0)
            {
                var errorsToIgnore = new List<DbValidationError>();
                foreach (var error in result.ValidationErrors)
                {
                    if (!entityEntry.Property(error.PropertyName).IsModified)
                    {
                        errorsToIgnore.Add(error);
                    }
                }

                foreach (var error in errorsToIgnore)
                {
                    result.ValidationErrors.Remove(error);
                }
            }

            // Return the modified error list
            return result;
        }
    }
}