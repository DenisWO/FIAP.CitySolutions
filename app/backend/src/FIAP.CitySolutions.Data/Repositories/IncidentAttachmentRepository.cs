using FIAP.CitySolutions.Data.DataAccess;
using FIAP.CitySolutions.Data.Repositories.Interfaces;
using FIAP.CitySolutions.Domain.Domain;

namespace FIAP.CitySolutions.Data.Repositories
{
    public class IncidentAttachmentRepository : Repository<IncidentAttachment>, IIncidentAttachmentRepository
    {
        public IncidentAttachmentRepository(DataContext context) : base(context) { }
    }
}
