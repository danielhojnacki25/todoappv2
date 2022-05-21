using System.Linq.Expressions;

namespace ToDo.Repository;

public interface IBaseRepository<T> where T : class
{
    Task<T?> GetByIdAsync(long id);
    IQueryable<T> FindByConditionAsync(Expression<Func<T, bool>> expression);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task RemoveAsync(T entity);
}