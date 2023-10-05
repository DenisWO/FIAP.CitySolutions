using FIAP.CitySolutions.Data.DataAccess;
using FIAP.CitySolutions.Data.Repositories.Interfaces;
using FIAP.CitySolutions.Domain.Domain;

namespace FIAP.CitySolutions.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context) {}
    }
}
