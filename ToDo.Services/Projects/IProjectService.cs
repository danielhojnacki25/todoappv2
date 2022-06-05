using ToDo.Common.Dtos.Projects;
using ToDo.Common.ViewModels.Projects;

namespace ToDo.Services.Projects;

public interface IProjectService
{
    Task<IList<ProjectDto>> GetProjectsAsync();
    Task CreateProjectAsync(CreateProjectViewModel project);
}