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

var app = builder.Build();

app.UseRouting();

app.MapControllers();

app.Run();