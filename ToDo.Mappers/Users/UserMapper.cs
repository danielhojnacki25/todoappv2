using ToDo.Common.Dtos.Users;
using ToDo.Data.Models;

namespace ToDo.Mappers.Users;

public static class UserMapper
{
    public static UserDto MapToDto(this User user) => new()
    {
        Id = user.Id,
        Email = user.Email,
        UserName = user.UserName,
    };
}