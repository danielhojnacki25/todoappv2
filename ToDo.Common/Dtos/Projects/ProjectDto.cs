using ToDo.Common.Dtos.AppTasks;
using ToDo.Common.Dtos.Common;
using ToDo.Common.Dtos.Users;

namespace ToDo.Common.Dtos.Projects;

public class ProjectDto : EntityDto
{
    public string Name { get; set; }
    public string Description { get; set; }

    public  UserDto UserDto { get; set; }
    public IList<AppTaskDto> AppTaskDtos { get; set; }
}