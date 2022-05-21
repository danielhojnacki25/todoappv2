using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.Common.Enums;
using ToDo.Data.Models;
using ToDo.Repository.AppTasks;
using ToDo.Repository.Users;
using ToDoApp.Services.Users.Queries.GetUserById;

namespace ToDo.Services.AppTasks.Commands.CreateTask;

public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Unit>
{
    private readonly IAppTaskRepository _appTaskRepository;
    private readonly IUserRepository _userRepository;

    public CreateTaskCommandHandler(IAppTaskRepository appTaskRepository, IUserRepository userRepository)
    {
        _appTaskRepository = appTaskRepository;
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var targetUser = await _userRepository.FindByConditionAsync(x => x.Id.Equals(request.NewAppTask.TargetUserId)).FirstOrDefaultAsync(cancellationToken: cancellationToken);
        var sourceUser = await _userRepository.FindByConditionAsync(x => x.Id.Equals(request.NewAppTask.SourceUserId)).FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (targetUser is null || sourceUser is null) return Unit.Value;

        var newTask = new AppTask(request.NewAppTask.Title, request.NewAppTask.Description, targetUser, sourceUser,
            request.NewAppTask.Status, request.NewAppTask.Priority);

        await _appTaskRepository.CreateAsync(newTask);
        return Unit.Value;
    }
}