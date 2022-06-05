using ToDo.Common.ViewModels.Identities;
using ToDo.Common.ViewModels.Identities.Results;

namespace ToDo.Services.Identities;

public interface IIdentityService
{
    Task<RegisterResult?> RegisterAsync(RegisterViewModel model);
    Task<LoginResult?> LoginAsync(LoginViewModel model);
    Task LogoutAsync();
}