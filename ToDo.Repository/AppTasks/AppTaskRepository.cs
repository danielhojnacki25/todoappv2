using Microsoft.EntityFrameworkCore;
using ToDo.Common.Dtos.AppTasks.Filters;
using ToDo.Data;
using ToDo.Data.Models;

namespace ToDo.Repository.AppTasks;

public class AppTaskRepository : BaseRepository<AppTask>, IAppTaskRepository
{
    private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

    public AppTaskRepository(IDbContextFactory<ApplicationDbContext> dbContextFactory) : base(dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task<IList<AppTask>> GetAppTasksByUserAsync(int take, int skip, AppTaskDtoFilter appTaskDtoFilter)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        var query = context.Tasks.AsQueryable();

        if (appTaskDtoFilter.IncludeSourceUser)
            query.Include(x => x.SourceUser);
        if(appTaskDtoFilter.IncludeTargetUser)
            query.Include(x => x.TargetUser);

        return await query.Skip(skip).Take(take).ToListAsync();
    }
}