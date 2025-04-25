using System.Linq.Expressions;

namespace Repositories
{
  public interface IBaseRepository<T> where T : class
  {
    IQueryable<T> GetAll();

    T FirstOrDefault(Expression<Func<T, bool>> predicate);

    void AddOrUpdate(int id, T entity);

    void UpdateSingleColumn<TProperty>(
                Expression<Func<T, bool>> predicate,
                Expression<Func<T, TProperty>> propertyExpression,
                TProperty newValue);

    public IQueryable<T> Where(Expression<Func<T, bool>> predicate);

    public IQueryable<T> OrderByDescending<TKey>(Expression<Func<T, TKey>> keySelector);

    // ASYNC

    Task<IEnumerable<T>> GetAllAsync();

    Task<T> GetByIdAsync(int id);

    Task AddAsync(T entity);

    Task UpdateAsync(T entity);

    Task AddOrUpdateAsync(int id, T entity);

    Task DeleteAsync(int id);
  }
}