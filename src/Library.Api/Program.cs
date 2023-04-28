using System.Reflection;
using Devpack.Notifications;
using Library.Api.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg =>
    {
        var assemblies = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")
            .Select(assembly 
                => Assembly.Load(AssemblyName.GetAssemblyName(assembly)));

        cfg.RegisterServicesFromAssemblies(assemblies.ToArray());
    });
builder.Services.ConfigureServices();
builder.Services.AddSmartNotification();

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