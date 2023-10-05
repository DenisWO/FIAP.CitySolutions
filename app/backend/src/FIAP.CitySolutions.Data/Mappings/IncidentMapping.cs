using FIAP.CitySolutions.Domain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FIAP.CitySolutions.Data.Mappings
{
    public class IncidentMapping : IEntityTypeConfiguration<Incident>
    {
        public void Configure(EntityTypeBuilder<Incident> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Title)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(i => i.Description)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Property(i => i.IncidentType)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(i => i.Longitude)
                .IsRequired();

            builder.Property(i => i.Latitude)
                .IsRequired();

            builder.HasMany(i => i.Attachments)
                .WithOne(a => a.Incident);
        }
    }
}
