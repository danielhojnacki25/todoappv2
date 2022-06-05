using MediatR;
using ToDo.Common.Dtos.AppTasks;
using ToDo.Common.Dtos.AppTasks.Filters;

namespace ToDo.Services.AppTasks.Queries.GetAppTasksByUser;

public class GetAppTasksByUserQuery : IRequest<IList<AppTaskDto>>
{
    public GetAppTasksByUserQuery(string userId, AppTaskDtoFilter appTaskDtoFilter)
    {
        UserId = userId;
        AppTaskDtoFilter = appTaskDtoFilter;
    }

    public string UserId { get; set; }
    public AppTaskDtoFilter AppTaskDtoFilter { get; set; }
}