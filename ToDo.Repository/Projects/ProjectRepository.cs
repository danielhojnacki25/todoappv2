using Microsoft.EntityFrameworkCore;
using ToDo.Common.Dtos.Projects;
using ToDo.Data;
using ToDo.Data.Models;

namespace ToDo.Repository.Projects;

public class ProjectRepository : BaseRepository<Project>, IProjectRepository
{
    private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;
    public ProjectRepository(IDbContextFactory<ApplicationDbContext> dbContextFactory) : base(dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task<IList<Project>> GetProjectsAsync()
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        var query = context.Projects.AsQueryable();
        query = query.Include(x => x.User);

        return await query.ToListAsync();
    }
}