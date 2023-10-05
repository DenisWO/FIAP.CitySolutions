using FIAP.CitySolutions.Data.DataAccess;
using FIAP.CitySolutions.Data.Repositories.Interfaces;
using FIAP.CitySolutions.Domain.Domain;

namespace FIAP.CitySolutions.Data.Repositories
{
    public class IncidentRepository : Repository<Incident>, IIncidentRepository
    {
        public IncidentRepository(DataContext context) : base(context) { }
    }
}
