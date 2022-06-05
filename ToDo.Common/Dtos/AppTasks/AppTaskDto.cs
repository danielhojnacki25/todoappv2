using ToDo.Common.Dtos.Common;
using ToDo.Common.Dtos.Projects;
using ToDo.Common.Dtos.Users;
using ToDo.Common.Enums;

namespace ToDo.Common.Dtos.AppTasks;

public sealed class AppTaskDto : EntityDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public Status Status { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime DeadlineDate { get; set; }
    public DateTime? EndDate { get; set; }
    public Priority Priority { get; set; }
    public  UserDto? TargetUser { get; set; }
    public  UserDto? SourceUser { get; set; }
    public  ProjectDto? ProjectDto { get; set; }

    public AppTaskDto()
    {
        TargetUser = new UserDto();
        SourceUser = new UserDto();
        ProjectDto = new ProjectDto();
    }
}