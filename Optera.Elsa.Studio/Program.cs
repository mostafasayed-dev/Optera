using Blazored.LocalStorage;
using Elsa.Studio.Contracts;
using Elsa.Studio.Core.BlazorWasm.Extensions;
using Elsa.Studio.Dashboard.Extensions;
using Elsa.Studio.Extensions;
using Elsa.Studio.Login.BlazorWasm.Extensions;
using Elsa.Studio.Login.Contracts;
using Elsa.Studio.Login.Extensions;
using Elsa.Studio.Models;
using Elsa.Studio.Shell;
using Elsa.Studio.Shell.Extensions;
using Elsa.Studio.Webhooks.Extensions;
using Elsa.Studio.Workflows.Designer.Extensions;
using Elsa.Studio.Workflows.Extensions;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using Optera.Elsa.Studio.Handlers;
using Optera.Elsa.Studio.Services;
using Optera.Elsa.Studio.Validator;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Root components
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.RootComponents.RegisterCustomElsaStudioElements();

// LocalStorage
builder.Services.AddBlazoredLocalStorage();

// Elsa Studio core modules
builder.Services.AddCore();
builder.Services.AddShell();
builder.Services.AddRemoteBackend(new BackendApiConfig
{
    ConfigureBackendOptions = options => builder.Configuration.GetSection("Backend").Bind(options),
    ConfigureHttpClientBuilder = options => options.AuthenticationHandler = typeof(AuthorizationMessageHandler)
});
builder.Services.AddLoginModule();
builder.Services.UseElsaIdentity();
builder.Services.AddDashboardModule();
builder.Services.AddWorkflowsModule();
builder.Services.AddWebhooksModule();

// Identity authentication
builder.Services.AddHttpClient("IdentityService", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["IdentityService:Url"]!);
});
builder.Services.AddScoped(sp =>
{
    var httpClient = sp.GetRequiredService<IHttpClientFactory>().CreateClient("IdentityService");
    var localStorage = sp.GetRequiredService<ILocalStorageService>();
    var js = sp.GetRequiredService<IJSRuntime>();
    return new IdentityAuthService(httpClient, localStorage, js);
});
builder.Services.AddScoped<IAuthorizationService, IdentityAuthService>();
builder.Services.AddScoped<ICredentialsValidator, OpteraCredentialsValidator>();

// Elsa server API client with JWT
builder.Services.AddTransient<AuthorizationMessageHandler>();
builder.Services.AddHttpClient("ElsaServer", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ElsaServer:Url"]!);
})
.AddHttpMessageHandler<AuthorizationMessageHandler>();
builder.Services.AddScoped(sp =>
    sp.GetRequiredService<IHttpClientFactory>().CreateClient("ElsaServer")
);

var app = builder.Build();

// Run startup tasks
var startupTaskRunner = app.Services.GetRequiredService<IStartupTaskRunner>();
await startupTaskRunner.RunStartupTasksAsync();

// Run the application
await app.RunAsync();
