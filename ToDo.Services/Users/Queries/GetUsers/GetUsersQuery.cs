using MediatR;
using ToDo.Common.Dtos.Users;

namespace ToDo.Services.Users.Queries.GetUsers;

public class GetUsersQuery : IRequest<IList<UserDto>>
{
    public GetUsersQuery(){}
}