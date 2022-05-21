using ToDo.Common.Dtos.AppTasks.Filters;
using ToDo.Data.Models;

namespace ToDo.Repository.AppTasks;

public interface IAppTaskRepository : IBaseRepository<AppTask>
{
    Task<IList<AppTask>> GetAppTasksByUserAsync(int take, int skip, AppTaskDtoFilter appTaskDtoFilter);
}