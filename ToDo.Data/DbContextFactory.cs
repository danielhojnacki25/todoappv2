using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ToDo.Data;

public class DbContextFactory<TContext>
    : IDbContextFactory<TContext> where TContext : DbContext
{
    private readonly IServiceProvider _serviceProvider;

    public DbContextFactory(IServiceProvider serviceProvider)
        => _serviceProvider = serviceProvider;

    public TContext CreateDbContext()
    {
        if(_serviceProvider is null)
            throw new InvalidOperationException(
                $"You must configure an instance of IServiceProvider");

        return ActivatorUtilities.CreateInstance<TContext>(_serviceProvider);
    }
}