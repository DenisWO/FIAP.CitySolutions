using FIAP.CitySolutions.Data.DataAccess;
using FIAP.CitySolutions.Data.Repositories.Interfaces;
using FIAP.CitySolutions.Domain.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FIAP.CitySolutions.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity    
    {
        private readonly DataContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public Repository(DataContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public async Task<bool> Commit()
        {
            return await _context.Commit();
        }

        public async Task<IQueryable<TEntity>> GetAll(params Expression<Func<TEntity, object>>[] includes)
        {
            var result = _dbSet.Where(x => x.Active == true);

            if (includes.Any())
                result = includes.Aggregate(result, (current, includeProperty) => current.Include(includeProperty));

            return result;
        }

        public async Task<TEntity> GetById(Guid id, params Expression<Func<TEntity, object>>[] includes)
        {
            var result = await GetAll(includes);

            return await result.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Save(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task<IQueryable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? top = null, int? skip = null, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = await GetAll(includes);

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                query = orderBy(query);

            if (skip.HasValue)
                query = query.Skip(skip.Value);

            if (top.HasValue)
                query = query.Take(top.Value);

            return query;
        }

        public async Task<TEntity> FindFirst(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? top = null, int? skip = null, params Expression<Func<TEntity, object>>[] includes)
        {
            var result = await Find(predicate, orderBy, top, skip, includes);
            return await result.FirstOrDefaultAsync();
        }
    }
}
