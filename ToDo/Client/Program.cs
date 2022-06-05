using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ToDo.Client;
using ToDo.Services.Identities;
using ToDo.Shared.Handlers;
using ToDo.Shared.Providers;
using MudBlazor.Services;
using ToDo.Services.AppTasks;
using ToDo.Services.Projects;
using ToDo.Services.Users;
using UsambiApp.Services.Users;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddOptions();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();

builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Resources";
});

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<AuthenticationStateProvider,
    ApiAuthenticationStateProvider>();
builder.Services.AddMudServices();

builder.Services.AddTransient<CustomAuthorizationHandler>();

builder.Services.AddScoped<IIdentityService, IdentityService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAppTaskService, AppTaskService>();
builder.Services.AddScoped<IProjectService, ProjectService>();

await builder.Build().RunAsync();
