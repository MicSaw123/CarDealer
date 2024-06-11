using CarDealer.Application.Interfaces.Database;
using CarDealer.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarDealer.Application.Repositories.Generic
{
    public abstract class GenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly IDbContext _context;

        protected readonly DbSet<TEntity> _entities;
        public GenericRepository(IDbContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public async Task Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public async Task<TEntity> FindByConditionAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(IEnumerable<Expression<Func<TEntity, object>>> includes = null)
        {
            IQueryable<TEntity> queryable = _entities.AsQueryable();

            if (includes is not null && includes.Any())
            {
                queryable = includes.Aggregate(queryable, (current, include) => current.Include(include));
            }
            return await queryable.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _entities.SingleOrDefaultAsync(t => t.Id == id);
        }

        public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false) > 0;
        }

        public async Task Delete(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _entities.Update(entity);
        }

    }
}
