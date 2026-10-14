using BookManager.Client.Pages;
using BookManager.Components;
using BookManager.Application.Interface;
using BookManager.Infrastructure.Repository.RestRepository;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IUserRepository, RestUserRepository>();
builder.Services.AddScoped<IAuthorRepository, RestAuthorRepository>();
builder.Services.AddScoped<ICategoryRepository, RestCategoryRepository>();
builder.Services.AddScoped<IBookRepository, RestBookRepository>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register authorization services
builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BookManager.Client._Imports).Assembly);

app.Run();
