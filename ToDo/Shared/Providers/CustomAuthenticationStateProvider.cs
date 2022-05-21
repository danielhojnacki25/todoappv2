using System.Net.Http.Json;
using System.Security.Claims;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using ToDo.Common.Dtos.Users;

namespace ToDo.Shared.Providers;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorage;

    public CustomAuthenticationStateProvider(HttpClient httpClient, ILocalStorageService localStorageService)
    {
        _httpClient = httpClient;
        _localStorage = localStorageService;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var identity = new ClaimsIdentity();
        var user = await _httpClient.GetFromJsonAsync<UserDto>($"api/v1/identity/getUserIdentity");
        if (user is {IsAuthenticated: true})
        {
            var claims = new[] {new Claim(ClaimTypes.Name, user.UserName)};
            identity = new ClaimsIdentity(claims, "serverAuth");
            return new AuthenticationState(new ClaimsPrincipal(identity));
        }
        else
        {
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }
    }
}