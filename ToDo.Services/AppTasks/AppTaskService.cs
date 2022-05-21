using Microsoft.Extensions.Configuration;
using ToDo.Common.ViewModels.AppTasks;

namespace ToDo.Services.AppTasks;

public class AppTaskService : IAppTaskService
{
    private readonly IConfiguration _configuration;

    public AppTaskService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task CreateAppTaskAsync(CreateAppTaskVewModel newAppTask)
    {
       // var response = await client.PostAsJsonAsync("api/v1/task/create", newAppTask);
    }
}