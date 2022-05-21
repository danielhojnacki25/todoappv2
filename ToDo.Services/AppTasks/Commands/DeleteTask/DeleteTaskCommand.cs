using MediatR;
using ToDo.Common.Dtos.AppTasks;

namespace ToDo.Services.AppTasks.Commands.DeleteTask;

public class DeleteTaskCommand : IRequest<Unit>
{
    public DeleteTaskCommand(AppTaskDto appTaskDto)
        => AppTaskDto = appTaskDto;

    public AppTaskDto AppTaskDto { get; set; }
}