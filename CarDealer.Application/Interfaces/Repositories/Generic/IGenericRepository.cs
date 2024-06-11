using System.Linq.Expressions;

namespace CarDealer.Application.Interfaces.Repositories.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(IEnumerable<Expression<Func<T, object>>> includes = default);

        Task<T> GetByIdAsync(int id);

        Task Add(T entity);

        Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);

        Task<T> FindByConditionAsync(Expression<Func<T, bool>> predicate);

        void Update(T entity);

        Task Delete(T entity);
    }
}
