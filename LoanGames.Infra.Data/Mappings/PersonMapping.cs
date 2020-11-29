using LoanGames.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanGames.Infra.Data.Mappings
{
    public class PersonMapping : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
              .IsRequired();

            builder.Property(x => x.Phone)
              .HasMaxLength(11);



        }
    }
}
