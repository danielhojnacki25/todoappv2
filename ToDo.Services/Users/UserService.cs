using System.Net.Http.Json;
using ToDo.Common.Dtos.Users;
using ToDo.Services.Users;

namespace UsambiApp.Services.Users;

public class UserService : IUserService
{
    private readonly HttpClient _httpClient;

    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<UserDto?> GetUserByUsernameAsync(string username)
    {
        var user = await _httpClient.GetFromJsonAsync<UserDto>($"api/v1/user/{username}");
        return user;
    }

    public async Task<IList<UserDto>> GetAppUsersAsync()
    {
        var users = await _httpClient.GetFromJsonAsync<IList<UserDto>>($"api/v1/User/all");
        return users;
    }
}