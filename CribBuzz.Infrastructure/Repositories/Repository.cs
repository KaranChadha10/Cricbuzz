using System.Linq.Expressions;
using CribBuzz.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using CribBuzz.Domain.Repositories.Interfaces;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly CribBuzzDbContext _context;
    private readonly DbSet<T> _dbSet;
    
    public Repository(CribBuzzDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }
    
    public async Task AddAync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
    }
}