using Microsoft.EntityFrameworkCore;
using BookManager.Data;
using BookManager.Data.Repository.EfRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<BookManager_DbContext>(option=>option.UseSqlServer
    ("Data Source=.;Initial Catalog=BookManager;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;"));
builder.Services.AddScoped<EfAuthorRepository>();
builder.Services.AddScoped<EfCategoryRepository>();
builder.Services.AddScoped<EfBookRepository>();

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

app.Run();
