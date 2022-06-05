using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using ToDo.Common.ViewModels.Identities;
using ToDo.Common.ViewModels.Identities.Results;
using ToDo.Shared.Providers;

namespace ToDo.Services.Identities;

public class IdentityService : IIdentityService
{
    private readonly HttpClient _httpClient;
    private readonly AuthenticationStateProvider _authenticationStateProvider;
    private readonly ILocalStorageService _localStorage;
    private readonly IConfiguration _configuration;

    public IdentityService(HttpClient httpClient, 
        AuthenticationStateProvider authenticationStateProvider, 
        ILocalStorageService localStorage,
        IConfiguration configuration)
    {
        _localStorage = localStorage;
        _httpClient = httpClient;
        _authenticationStateProvider = authenticationStateProvider;
        _configuration = configuration;
    }

    public async Task<RegisterResult?> RegisterAsync(RegisterViewModel model)
    { 
        var response = await _httpClient.PostAsJsonAsync("api/v1/identity/register", model);
        return await response.Content.ReadFromJsonAsync<RegisterResult>();
    }

    public async Task<LoginResult?> LoginAsync(LoginViewModel model)
    {
        var loginAsJson = JsonSerializer.Serialize(model);
        var response = await _httpClient.PostAsync("api/v1/identity/signin",
            new StringContent(loginAsJson, Encoding.UTF8, "application/json"));

        var loginResult = JsonSerializer.Deserialize<LoginResult>(
            await response.Content.ReadAsStringAsync(),
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        if (!response.IsSuccessStatusCode)
        {
            return loginResult;
        }

        if (loginResult is not null)
        {
            await _localStorage.SetItemAsync("_auth_token", loginResult.Token);
            ((ApiAuthenticationStateProvider)_authenticationStateProvider)
                .MarkUserAsAuthenticated(model.EmailOrUsername);
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", loginResult.Token);

            return loginResult;
        }

        return new LoginResult();
    }

    public async Task LogoutAsync()
    {
        var response = await _httpClient.PostAsync("api/v1/identity/logout", null);
        await _localStorage.RemoveItemAsync("_auth_token");
    }
}