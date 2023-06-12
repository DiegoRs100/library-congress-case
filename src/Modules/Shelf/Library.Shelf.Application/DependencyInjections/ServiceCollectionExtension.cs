using Library.Shelf.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Shelf.Application.DependencyInjections;

public static class ServiceCollectionExtension
{
    public static IServiceCollection ConfigureShelfApplication(this IServiceCollection services)
        => services.AddScoped<IApplicationService, ApplicationService>();
}
