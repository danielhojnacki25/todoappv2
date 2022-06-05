using MediatR;
using ToDo.Common.Dtos.Users;

namespace ToDo.Services.Users.Queries.GetUserByUserName;

public class GetUserByUserNameQuery : IRequest<UserDto?>
{
    public GetUserByUserNameQuery(string userName)
        => UserName = userName;

    public string UserName { get; set; }
}