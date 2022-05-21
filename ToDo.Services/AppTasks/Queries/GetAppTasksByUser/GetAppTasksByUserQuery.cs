using MediatR;
using ToDo.Common.Dtos.AppTasks;
using ToDo.Common.Dtos.AppTasks.Filters;

namespace ToDo.Services.AppTasks.Queries.GetAppTasksByUser;

public class GetAppTasksByUserQuery : IRequest<IList<AppTaskDto>>
{
    public GetAppTasksByUserQuery(string userId, int take, int skip, AppTaskDtoFilter appTaskDtoFilter)
    {
        UserId = userId;
        Take = take;
        Skip = skip;
        AppTaskDtoFilter = appTaskDtoFilter;
    }

    public string UserId { get; set; }
    public int Take { get; set; }
    public int Skip { get; set; }
    public AppTaskDtoFilter AppTaskDtoFilter { get; set; }
}