using System.Net.Http.Headers;
using Blazored.LocalStorage;

namespace ToDo.Shared.Handlers; 

public class CustomAuthorizationHandler : DelegatingHandler
{
    public ILocalStorageService LocalStorageService { get; set; }

    public CustomAuthorizationHandler(ILocalStorageService localStorageService)
    { 
        LocalStorageService = localStorageService;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var jwtToken = await LocalStorageService.GetItemAsync<string>("_auth_token");

        if (jwtToken is not null)
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

        return await base.SendAsync(request, cancellationToken);
    }
}