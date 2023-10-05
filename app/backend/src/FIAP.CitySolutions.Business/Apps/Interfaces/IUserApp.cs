using FIAP.CitySolutions.Business.Models.DTOs;
using FIAP.CitySolutions.Domain.Domain;

namespace FIAP.CitySolutions.Business.Apps.Interfaces
{
    public interface IUserApp : IApp<UserDTO>
    {
        Task<AppResponse<UserToken>> Login(UserLoginDTO userLoginDTO);
    }
}
