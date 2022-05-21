using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.Repository.AppTasks;

namespace ToDo.Services.AppTasks.Commands.DeleteTask;

public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, Unit>
{
    private readonly IAppTaskRepository _appTaskRepository;

    public DeleteTaskCommandHandler(IAppTaskRepository appTaskRepository)
        => _appTaskRepository = appTaskRepository;

    public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await _appTaskRepository.FindByConditionAsync(x => x.Id == request.AppTaskDto.Id).FirstOrDefaultAsync(cancellationToken: cancellationToken);
        if (task == null) return Unit.Value;
        await _appTaskRepository.RemoveAsync(task);
        return Unit.Value;
    }
}