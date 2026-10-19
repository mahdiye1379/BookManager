using BookManager.Application.Interface;
using BookManager.Infrastructure;
using BookManager.Infrastructure.Repository.EfRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<BookManager_DbContext>(option=>option.UseSqlServer
    ("Data Source=.;Initial Catalog=BookManager;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;"));
builder.Services.AddScoped<IAuthorRepository,EfAuthorRepository>();
builder.Services.AddScoped<ICategoryRepository,EfCategoryRepository>();
builder.Services.AddScoped<IBookRepository,EfBookRepository>();
builder.Services.AddScoped<IUserRepository,EfUserRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("BlazorClient", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("BlazorClient");

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();
app.UseStaticFiles();
app.Run();
