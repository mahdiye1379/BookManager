using BookManager.Client.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();

builder.Services.AddCascadingAuthenticationState();

IServiceCollection serviceCollection = builder.Services.AddScoped<CustomAuthStatProvider>();

builder.Services.AddScoped<AuthenticationStateProvider>(
    sp => sp.GetRequiredService<CustomAuthStatProvider>());

await builder.Build().RunAsync();
