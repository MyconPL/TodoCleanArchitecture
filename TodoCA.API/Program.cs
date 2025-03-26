using Microsoft.EntityFrameworkCore;
using Serilog;
using TodoCA.API.Persistence;
using TodoCA.API.Repoitories;
using TodoCA.API.Repositories;
using TodoCA.API.Services;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Rejestracja Seriloga
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("logs/api_logs.txt")
    .CreateLogger();
builder.Host.UseSerilog();

// 🔹 Rejestracja usług DI
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IToDoItemService, ToDoItemService>();
builder.Services.AddScoped<IToDoItemRepository, ToDoItemRepository>();

// 🔹 Dodanie kontrolerów, CORS i Swaggera
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// ⬇️ Dopiero teraz budujemy aplikację
var app = builder.Build();

// 🔹 Middleware i konfiguracja HTTP Pipeline
app.UseCors("AllowSpecificOrigin");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// 🔹 Zamknięcie logowania przy zamknięciu aplikacji
app.Lifetime.ApplicationStopped.Register(() =>
{
    Log.CloseAndFlush();
});

app.Run();
