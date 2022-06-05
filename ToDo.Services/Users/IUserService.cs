using ToDo.Common.Dtos.Users;

namespace ToDo.Services.Users;

public interface IUserService
{
    Task<UserDto?> GetUserByUsernameAsync(string username);
    Task<IList<UserDto>> GetAppUsersAsync();
}