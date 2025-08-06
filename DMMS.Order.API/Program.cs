using DMMS.Order.Application.Interfaces;
using DMMS.Order.Domain.Interfaces;
using DMMS.Order.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Добавляем контроллеры
builder.Services.AddControllers();

// Настраиваем контекст базы данных с PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Добавляем зависимости для DI
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
    
// Добавляем Swagger для документации
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Подключаем Swagger только в режиме разработки
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Маршрутизируем контроллеры
app.MapControllers();

// Принудительно перенаправляем HTTP на HTTPS
app.UseHttpsRedirection();

// Запускаем приложение
app.Run();
