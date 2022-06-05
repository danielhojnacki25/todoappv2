using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.Common.Dtos.Users;
using ToDo.Mappers.Users;
using ToDo.Repository.Users;

namespace ToDo.Services.Users.Queries.GetUserByUserName;

public class GetUserByUserNameQueryHandler : IRequestHandler<GetUserByUserNameQuery, UserDto?>
{
    private readonly IUserRepository _applicationUserRepository;

    public GetUserByUserNameQueryHandler(IUserRepository applicationUserRepository)
        => _applicationUserRepository = applicationUserRepository;

    public async Task<UserDto?> Handle(GetUserByUserNameQuery query, CancellationToken cancellationToken)
        => (await _applicationUserRepository
                .FindByConditionAsync(x => x.UserName.ToLower().Equals(query.UserName.ToLower())).FirstOrDefaultAsync(cancellationToken: cancellationToken))
            ?.MapToDto();
}