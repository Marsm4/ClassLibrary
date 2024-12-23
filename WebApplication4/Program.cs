using Microsoft.EntityFrameworkCore;
using Clinical_Hospital_33.Data;
using Clinical_Hospital_33.Repositories;
using Clinical_Hospital_33.Services;

var builder = WebApplication.CreateBuilder(args);

// Добавьте контекст базы данных
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Добавьте репозитории и сервисы
builder.Services.AddScoped<IVrachRepository, VrachRepository>(); // Регистрация репозитория
builder.Services.AddScoped<IVrachService, VrachService>(); // Регистрация сервиса

// Добавьте контроллеры
builder.Services.AddControllers();

var app = builder.Build();

// Настройте конвейер запросов
app.UseRouting();
app.MapControllers();

app.Run();