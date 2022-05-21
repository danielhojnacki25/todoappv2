using ToDo.Common.ViewModels.AppTasks;

namespace ToDo.Services.AppTasks;

public interface IAppTaskService
{
    Task CreateAppTaskAsync(CreateAppTaskVewModel newAppTask);
}