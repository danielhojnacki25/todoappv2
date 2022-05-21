using MediatR;
using ToDo.Common.Dtos.AppTasks;
using ToDo.Mappers.AppTasks;
using ToDo.Repository.AppTasks;
using ToDo.Services.AppTasks.Queries.GetAppTaskById;

namespace ToDoApp.Services.AppTasks.Queries.GetAppTaskById;

public class GetAppTaskByIdQueryHandler : IRequestHandler<GetAppTaskByIdQuery, AppTaskDto?>
{
    private readonly IAppTaskRepository _appTaskRepository;
    
    public GetAppTaskByIdQueryHandler(IAppTaskRepository appTaskRepository)
        => _appTaskRepository = appTaskRepository;

    public async Task<AppTaskDto?> Handle(GetAppTaskByIdQuery request, CancellationToken cancellationToken)
        => (await _appTaskRepository.GetByIdAsync(request.Id))?.MapToDto();

}