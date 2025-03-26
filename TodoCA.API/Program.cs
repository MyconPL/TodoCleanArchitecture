using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TodoCA.API.Repoitories;
using TodoCA.API.Repositories;
using TodoCA.API.Services;
using TodoCA.API.Persistence;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DbContext>(options =>
    options.UseSqlServer(connectionString));

// Dodanie serwisów do Dependency Injection (DI)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Rejestracja własnych serwisów (DI)
builder.Services.AddScoped<IToDoItemService, ToDoItemService>();
builder.Services.AddScoped<IToDoItemRepository, ToDoItemRepository>();

var app = builder.Build();

// Konfiguracja HTTP Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
