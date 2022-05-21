using MediatR;
using ToDo.Common.ViewModels.AppTasks;

namespace ToDo.Services.AppTasks.Commands.CreateTask;

public class CreateTaskCommand : IRequest<Unit>
{
    public CreateTaskCommand(CreateAppTaskVewModel newAppTask)
        => NewAppTask = newAppTask;

    public CreateAppTaskVewModel NewAppTask { get; set; }
}