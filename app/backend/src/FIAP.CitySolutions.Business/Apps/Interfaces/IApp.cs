using FIAP.CitySolutions.Business.Models.DTOs;

namespace FIAP.CitySolutions.Business.Apps.Interfaces
{
    public interface IApp<TEntity> where TEntity : EntityDTO
    {
        Task<AppResponse<List<TEntity>>> GetAll();
        Task<AppResponse<TEntity>> GetById(Guid id);
        Task<AppResponse<TEntity>> Save(TEntity entity);
        Task<AppResponse<TEntity>> Update(TEntity entity);
        Task<AppResponse<bool>> Delete(Guid id);
    }
}
