using LoanGames.Domain.Entities;
using LoanGames.Domain.Interfaces.Repositories;
using LoanGames.Domain.Mediator;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Linq;
using LoanGames.Infra.Data.Mappings;

namespace LoanGames.Infra.Data.Contexts
{
    public class MainContext : DbContext, IUnitOfWork
    {
       private readonly IMediatorHandler _mediatorHandler;

        public MainContext(DbContextOptions<MainContext> options, IMediatorHandler mediatorHandler) : base(options)
        {
            _mediatorHandler = mediatorHandler;
            ChangeTracker.AutoDetectChangesEnabled = true;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<bool> Commit()
        {
           // await _mediatorHandler.PublishDomainEvents(this).ConfigureAwait(false);
            return await SaveChangesAsync() > 0;
        }


        public DbSet<Person> Persons { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            // modelBuilder.Ignore<Event>();
                       
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entity.GetProperties().Where(p => p.ClrType == typeof(string)))
                {
                    property.SetMaxLength(100);
                }
            }


            modelBuilder.ApplyConfiguration(new PersonMapping());
            modelBuilder.ApplyConfiguration(new GameMapping());
            modelBuilder.ApplyConfiguration(new LoanMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
