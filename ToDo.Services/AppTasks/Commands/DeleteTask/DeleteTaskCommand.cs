using MediatR;
using ToDo.Common.Dtos.AppTasks;

namespace ToDo.Services.AppTasks.Commands.DeleteTask;

public class DeleteTaskCommand : IRequest<Unit>
{
    public DeleteTaskCommand(long id)
        => Id = id;

    public long Id { get; set; }
}