using ToDo.Common.Dtos.AppTasks;
using ToDo.Common.ViewModels.AppTasks;

namespace ToDo.Services.AppTasks;

public interface IAppTaskService
{
    Task CreateAppTaskAsync(CreateAppTaskVewModel newAppTask);
    Task<IList<AppTaskDto>>  GetTasksByUserIdAsync(string userId);
    Task  DeleteTaskAsync(long taskId);
}