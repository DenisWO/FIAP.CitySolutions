using FIAP.CitySolutions.Data.DataAccess;
using FIAP.CitySolutions.Data.Repositories.Interfaces;
using FIAP.CitySolutions.Domain.Domain;

namespace FIAP.CitySolutions.Data.Repositories
{
    public class ResponsibleRepository: Repository<Responsible>, IResponsibleRepository
    {
        public ResponsibleRepository(DataContext context) : base(context) { }
    }
}
