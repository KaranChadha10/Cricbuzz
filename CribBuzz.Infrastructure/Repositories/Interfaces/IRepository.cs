using System.Linq.Expressions;

namespace CribBuzz.Infrastructure.Repositories.Interfaces;
public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task AddAync (T entity);
    void UpdateAsync(T entity);
    void Delete(T entity);
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    Task SaveChangesAsync();
}