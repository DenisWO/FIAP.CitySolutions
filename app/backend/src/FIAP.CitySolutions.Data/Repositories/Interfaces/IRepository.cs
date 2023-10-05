using FIAP.CitySolutions.Domain.Domain;
using System.Linq.Expressions;

namespace FIAP.CitySolutions.Data.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<IQueryable<TEntity>> GetAll(params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> GetById(Guid id, params Expression<Func<TEntity, object>>[] includes);
        Task<IQueryable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate = null, 
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? top = null, int? skip = null,
            params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> FindFirst(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? top = null, int? skip = null,
            params Expression<Func<TEntity, object>>[] includes);
        Task Save(TEntity entity);
        Task<bool> Commit();
        
    }
}
