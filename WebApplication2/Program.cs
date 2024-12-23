using ClassLibrary;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Добавляем сервисы для контроллеров
builder.Services.AddControllers();

// Добавляем Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Настройка подключения к базе данных
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Добавляем сервисы
builder.Services.AddScoped<IVrachService, VrachService>();


var app = builder.Build();

// Включаем Swagger при разработке
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Это включает интерфейс Swagger UI
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
