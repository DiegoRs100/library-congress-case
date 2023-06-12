using Library.Shelf.Application.Abstactions.Repositories;
using Library.Shelf.Infra.Databases;
using Library.Shelf.Infra.Databases.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Library.Shelf.Infra.DependencyInjections;

public static class ServiceCollectionExtension
{
    public static IServiceCollection ConfigureShelfDbContext(this IServiceCollection services, IConfiguration configuration)
            => services.AddDbContextPool<DbContext, ShelfDbContext>((provider, builder) =>
            {
                builder
                    .EnableDetailedErrors()
                    .EnableSensitiveDataLogging()
                    .UseSqlServer(
                        connectionString: configuration.GetConnectionString("LibraryCongressDb"),
                        sqlServerOptionsAction: options
                            => options.MigrationsAssembly(typeof(ShelfDbContext).Assembly.GetName().Name));
            });

    public static IServiceCollection ConfigureShelfRepositories(this IServiceCollection services)
        => services.AddScoped<IShelfRepository, ShelfRepository>(); 
}
