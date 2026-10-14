using BookManager.Client.Authentication;
using BookManager.Application.Interface;
using BookManager.Infrastructure.Repository.RestRepository;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();

builder.Services.AddCascadingAuthenticationState();

builder.Services.AddScoped<IUserRepository,RestUserRepository>();
builder.Services.AddScoped<IAuthorRepository,RestAuthorRepository>();
builder.Services.AddScoped<ICategoryRepository,RestCategoryRepository>();
builder.Services.AddScoped<IBookRepository,RestBookRepository>();


IServiceCollection serviceCollection = builder.Services.AddScoped<CustomAuthStatProvider>();

builder.Services.AddScoped<AuthenticationStateProvider>(
    sp => sp.GetRequiredService<CustomAuthStatProvider>());

await builder.Build().RunAsync();
