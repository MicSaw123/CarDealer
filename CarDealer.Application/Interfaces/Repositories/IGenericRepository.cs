using System.Linq.Expressions;

namespace CarDealer.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(IEnumerable<Expression<Func<T, object>>> includes = default);

        Task<T> GetByIdAsync(int id);

        void Add(T entity);

        Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);

        Task<T> FindByConditionAsync(Expression<Func<T, bool>> predicate);
    }
}
