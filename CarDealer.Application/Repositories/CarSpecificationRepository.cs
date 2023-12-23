using CarDealer.Application.Interfaces.Database;
using CarDealer.Application.Interfaces.Repositories;
using CarDealer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarDealer.Application.Repositories
{
    public class CarSpecificationRepository : ICarSpecificationRepository
    {
        private readonly IDbContext _context;

        private readonly DbSet<CarSpecification> _entities;

        public CarSpecificationRepository(IDbContext context)
        {
            _context = context;
            _entities = context.Set<CarSpecification>();
        }

        public void Add(CarSpecification entity)
        {
            _entities.Add(entity);
        }

        public async Task<CarSpecification> FindByConditionAsync(Expression<Func<CarSpecification, bool>> predicate)
        {
            return await _context.Set<CarSpecification>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<CarSpecification>> GetAllAsync(IEnumerable<Expression<Func<CarSpecification, object>>> includes = null)
        {
            IQueryable<CarSpecification> queryable = _entities.AsQueryable();

            if (includes is not null && includes.Any())
            {
                queryable = includes.Aggregate(queryable, (current, include) => current.Include(include));
            }
            return await queryable.ToListAsync();
        }

        public async Task<CarSpecification> GetByIdAsync(int id)
        {
            return await _entities.SingleOrDefaultAsync(cs => cs.Id == id);
        }

        public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false) > 0;
        }
    }
}
