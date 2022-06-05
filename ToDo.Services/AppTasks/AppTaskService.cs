using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using ToDo.Common.Dtos.AppTasks;
using ToDo.Common.ViewModels.AppTasks;

namespace ToDo.Services.AppTasks;

public class AppTaskService : IAppTaskService
{
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;

    public AppTaskService(IConfiguration configuration, HttpClient httpClient)
    {
        _configuration = configuration;
        _httpClient = httpClient;
    }

    public async Task CreateAppTaskAsync(CreateAppTaskVewModel newAppTask)
    {
       var response = await _httpClient.PostAsJsonAsync("api/v1/task/create", newAppTask);
    }

    public async Task<IList<AppTaskDto>> GetTasksByUserIdAsync(string userId)
    {
        var tasks = await _httpClient.GetFromJsonAsync<IList<AppTaskDto>>($"api/v1/Task/user/{userId}/tasks");
        return tasks;
    }

    public async Task DeleteTaskAsync(long taskId)
    {
        var response = await _httpClient.PostAsJsonAsync("api/v1/task/delete", taskId);
    }

    public async Task GetTasksAsync()
    {
    }
}