using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ToDo.Data;

namespace ToDo.Repository;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

    public BaseRepository(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        => _dbContextFactory = dbContextFactory;

    public async Task<T?> GetByIdAsync(long id)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        return await context.Set<T>().FindAsync(id);
    }
    public IQueryable<T> FindByConditionAsync(Expression<Func<T, bool>> expression)
    {
        var context = _dbContextFactory.CreateDbContext();
        return context.Set<T>().Where(expression);
    }
    public async Task CreateAsync(T entity)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        await context.Set<T>().AddAsync(entity);
        await context.SaveChangesAsync();
    }
    public async Task UpdateAsync(T entity)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        context.Set<T>().Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task RemoveAsync(T entity)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        context.Set<T>().Remove(entity);
        await context.SaveChangesAsync();
    }
}