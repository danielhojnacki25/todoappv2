using MediatR;
using ToDo.Common.Dtos.Users;

namespace ToDoApp.Services.Users.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<UserDto?>
{
    public GetUserByIdQuery(string userId)
        => UserId = userId;

    public string UserId { get; set; }
}