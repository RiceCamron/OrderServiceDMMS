using System.Linq.Expressions;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

try
{
    // Создание билдера приложения
    var builder = WebApplication.CreateBuilder(args);

    // Добавление конфигурационного файла Ocelot (обязательно, не опционально)
    builder.Configuration.AddJsonFile("Ocelots/ocelot.json", optional: false, reloadOnChange: true);
    
    // Добавление служб Ocelot в DI-контейнер
    builder.Services.AddOcelot();

    // Настройка HTTPS редиректа (отключен, т.к. HttpsPort = null
    builder.Services.AddHttpsRedirection(options => { options.HttpsPort = null; });

    //Настройка политики CORS (разрешает любые источники, методы, заголовки и включает куки)
    builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(corsPolicyBuilder =>
        {
            corsPolicyBuilder
                .SetIsOriginAllowed(_ => true) // Разрешает все домены
                .AllowAnyMethod() // Разрешает любые HTTP-методы
                .AllowAnyHeader() // Разрешает любые заголовки
                .AllowCredentials() // Разрешает отправку куки и авторизационных данных
                .WithExposedHeaders("Content-Type", "Authoruzation"); // Заголовки, которые можно будет читать клиенте
        });
    });

    // Построение приложения
    var app = builder.Build();
    
    // Применение политики CORS ко всем запросам
    app.UseCors();
    
    // Использование middleware Ocelot (запускает маршрутизацию через Ocelot)
    await app.UseOcelot();

    // Запуск приложения
    app.Run();
}
catch (Exception ex)
{
    // Вывод ошибки в консоль, если приложение не запустилось
    Console.WriteLine(ex);
}