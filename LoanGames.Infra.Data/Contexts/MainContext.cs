using LoanGames.Domain.Entities;
using LoanGames.Domain.Interfaces.Repositories;
using LoanGames.Domain.Mediator;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Linq;
using LoanGames.Infra.Data.Mappings;
using NetDevPack.Data;

namespace LoanGames.Infra.Data.Contexts
{
    public class MainContext : DbContext, IUnitOfWork
    {

        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public async Task<bool> Commit()
        {
            return await SaveChangesAsync() > 0;
        }


        public DbSet<Person> Persons { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entity.GetProperties().Where(p => p.ClrType == typeof(string)))
                {
                    property.SetMaxLength(100);
                }
            }

            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new PersonMapping());
            modelBuilder.ApplyConfiguration(new GameMapping());
            modelBuilder.ApplyConfiguration(new LoanMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
