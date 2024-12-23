using Microsoft.EntityFrameworkCore;
using Clinical_Hospital_33.Data;
using Clinical_Hospital_33.Repositories;
using Clinical_Hospital_33.Services;

var builder = WebApplication.CreateBuilder(args);

// ��������� �������� ���� ������
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ��������� ����������� � �������
builder.Services.AddScoped<IVrachRepository, VrachRepository>();
builder.Services.AddScoped<IVrachService, VrachService>();

// ��������� �����������
builder.Services.AddControllers();

// ��������� Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// �������� Swagger � Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.MapControllers();

app.Run();