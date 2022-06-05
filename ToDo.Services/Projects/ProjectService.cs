using System.Net.Http.Json;
using ToDo.Common.Dtos.Projects;
using ToDo.Common.ViewModels.Projects;

namespace ToDo.Services.Projects;

public class ProjectService : IProjectService
{
    private readonly HttpClient _httpClient;

    public ProjectService(HttpClient httpClient)
        => _httpClient = httpClient;


    public async Task<IList<ProjectDto>> GetProjectsAsync()
    {
       var projects = await _httpClient.GetFromJsonAsync<IList<ProjectDto>>($"api/v1/projects");
       return projects;
    }

    public async Task CreateProjectAsync(CreateProjectViewModel project)
    {
        var response = await _httpClient.PostAsJsonAsync("api/v1/projects/create", project);
    }
}