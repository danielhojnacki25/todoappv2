using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.Common.Dtos.AppTasks;
using ToDo.Common.Dtos.AppTasks.Filters;
using ToDo.Mappers.AppTasks;
using ToDo.Repository.AppTasks;
using ToDo.Repository.Users;

namespace ToDo.Services.AppTasks.Queries.GetAppTasksByUser;

public class GetAppTasksByUserQueryHandler : IRequestHandler<GetAppTasksByUserQuery, IList<AppTaskDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IAppTaskRepository _appTaskRepository;

    public GetAppTasksByUserQueryHandler(IUserRepository userRepository, IAppTaskRepository appTaskRepository)
    {
        _appTaskRepository = appTaskRepository;
        _userRepository = userRepository;
    }

    public async Task<IList<AppTaskDto>> Handle(GetAppTasksByUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindByConditionAsync(x => x.Id.Equals(request.UserId)).FirstOrDefaultAsync(cancellationToken: cancellationToken);
        if (user == null) return new List<AppTaskDto>();

        var tasks = await _appTaskRepository.GetAppTasksByUserAsync(request.Take, request.Skip, request.AppTaskDtoFilter);
        return tasks.Select(x => x.MapToDto()).ToList();
    }
}