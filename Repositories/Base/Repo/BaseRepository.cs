using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repositories
{
  public class BaseRepository<T> : IBaseRepository<T> where T : class
  {
    protected readonly AppDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public BaseRepository(AppDbContext context)
    {
      _context = context;
      _dbSet = context.Set<T>();
    }

    public IQueryable<T> GetAll()
    {
      return _context.Set<T>();
    }

    public T FirstOrDefault(Expression<Func<T, bool>> predicate)
    {
      return _context.Set<T>().FirstOrDefault(predicate);
    }

    public void AddOrUpdate(int id, T entity)
    {
      var existingEntity = _context.Set<T>().Find(id);
      if (existingEntity == null)
      {
        _context.Set<T>().Add(entity);
      }
      else
      {
        _context.Entry(existingEntity).CurrentValues.SetValues(entity);
      }
      _context.SaveChanges();
    }

    public void UpdateSingleColumn<TProperty>(
                Expression<Func<T, bool>> predicate,
                Expression<Func<T, TProperty>> propertyExpression,
                TProperty newValue)
    {
      var entities = _dbSet.Where(predicate).ToList();

      foreach (var entity in entities)
      {
        var property = _context.Entry(entity).Property(propertyExpression);
        property.CurrentValue = newValue;
        property.IsModified = true;
      }

      _context.SaveChanges();
    }

    public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
    {
      return _dbSet.Where(predicate);
    }

    public IQueryable<T> OrderByDescending<TKey>(Expression<Func<T, TKey>> keySelector)
    {
      return _dbSet.OrderByDescending(keySelector);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
      return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
      return await _context.Set<T>().FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
      await _context.Set<T>().AddAsync(entity);
      await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
      _context.Set<T>().Update(entity);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
      var entity = await GetByIdAsync(id);
      _context.Set<T>().Remove(entity);
      await _context.SaveChangesAsync();
    }

    public async Task AddOrUpdateAsync(int id, T entity)
    {
      var existingEntity = await _context.Set<T>().FindAsync(id);
      if (existingEntity == null)
      {
        await AddAsync(entity);
      }
      else
      {
        _context.Entry(existingEntity).CurrentValues.SetValues(entity);
        await _context.SaveChangesAsync();
      }
    }
  }
}