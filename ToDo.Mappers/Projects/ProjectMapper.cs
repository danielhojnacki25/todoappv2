using ToDo.Common.Dtos.Projects;
using ToDo.Common.Dtos.Users;
using ToDo.Data.Models;
using ToDo.Mappers.AppTasks;
using ToDo.Mappers.Users;

namespace ToDo.Mappers.Projects;

public static class ProjectMapper
{
    public static ProjectDto MapToDto(this Project project) => new()
    {
        Description = project.Description,
        Id = project.Id,
        Name = project.Name,
        UserDto = project.User?.MapToDto()
    };
}