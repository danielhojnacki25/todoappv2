using MediatR;
using ToDo.Common.Dtos.AppTasks;

namespace ToDo.Services.AppTasks.Queries.GetAppTaskById;

public class GetAppTaskByIdQuery: IRequest<AppTaskDto?>
{
    public GetAppTaskByIdQuery(long id)
        => Id = id;
    
    public long Id { get; set; }
}