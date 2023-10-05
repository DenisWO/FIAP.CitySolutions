using FIAP.CitySolutions.Domain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FIAP.CitySolutions.Data.Mappings
{
    public class IncidentAttachmentMapping : IEntityTypeConfiguration<IncidentAttachment>
    {
        public void Configure(EntityTypeBuilder<IncidentAttachment> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                .IsRequired();

            builder.Property(a => a.Path) 
                .IsRequired();
        }
    }
}
