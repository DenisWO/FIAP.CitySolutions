using FIAP.CitySolutions.Domain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FIAP.CitySolutions.Data.Mappings
{
    public class ResponsibleMapping : IEntityTypeConfiguration<Responsible>
    {
        public void Configure(EntityTypeBuilder<Responsible> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Name)
                .IsRequired();

            builder.Property(r => r.Document)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.HasMany(r => r.Incidents)
                .WithOne(i => i.Responsible);
        }
    }
}
