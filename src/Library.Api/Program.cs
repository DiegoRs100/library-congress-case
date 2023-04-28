using System.Reflection;
using Devpack.Notifications;
using Library.Api.Config;

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

        services.AddMediatR(configuration =>
        {
            var assemblies = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")
            .Select(assembly
                => Assembly.Load(AssemblyName.GetAssemblyName(assembly)));

            configuration.RegisterServicesFromAssemblies(assemblies.ToArray());
        });

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