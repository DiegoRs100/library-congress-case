using System.Reflection;
using Devpack.Notifications;
using Library.Api.DependencyInjection;
using Library.Shelf.Application.DependencyInjections;
using Library.Shelf.Infra.DependencyInjections;

var builder = WebApplication.CreateBuilder(args);

builder.Host
    .UseDefaultServiceProvider((context, provider) =>
    {
        provider.ValidateScopes = true;
        provider.ValidateOnBuild= true;
    })
    .ConfigureAppConfiguration((context, configurationBuilder) =>
    {
        configurationBuilder
            .AddUserSecrets(Assembly.GetExecutingAssembly())
            .AddEnvironmentVariables();
    })
    .ConfigureServices((context, services) =>
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.ConfigureShelfDbContext(context.Configuration);
        services.ConfigureShelfRepositories();
        services.ConfigureShelfApplication();

        services.ConfigureMediatR();
        //services.ConfigureServices();
        services.AddSmartNotification();
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();