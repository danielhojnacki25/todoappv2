using MediatR;
using ToDo.Common.Dtos.Users;
using ToDo.Mappers.Users;
using ToDo.Repository.Users;

namespace ToDo.Services.Users.Queries.GetUsers;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IList<UserDto>>
{
    private readonly IUserRepository _applicationUserRepository;

    public GetUsersQueryHandler(IUserRepository applicationUserRepository)
        => _applicationUserRepository = applicationUserRepository;

    public async Task<IList<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _applicationUserRepository.GetAllAsync();
        return users.Select(x => x.MapToDto()).ToList();
    }
}