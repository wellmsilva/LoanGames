using LoanGames.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanGames.Infra.Data.Mappings
{
    class LoanMapping : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Game)
                .WithMany(x => x.Loans)
                .HasForeignKey(x => x.Game_Id);
            
            builder.HasOne(x => x.Person)
                .WithMany(x => x.Loans)
                .HasForeignKey(x => x.Person_Id);
        }
    }
}
