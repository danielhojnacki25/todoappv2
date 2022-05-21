using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.Common.Dtos.Users;
using ToDo.Mappers.Users;
using ToDo.Repository.Users;

namespace ToDoApp.Services.Users.Queries.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto?>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository)
        => _userRepository = userRepository;

    public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        => (await _userRepository.FindByConditionAsync(x => x.Id.Equals(request.UserId)).FirstOrDefaultAsync(cancellationToken: cancellationToken))?.MapToDto();
}