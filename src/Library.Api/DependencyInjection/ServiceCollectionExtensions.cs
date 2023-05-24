using Library.Account.Application;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Library.Api.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
            => services.AddAccountModule();

        public static IServiceCollection ConfigureMediatR(this IServiceCollection services)
            => services.AddMediatR(configuration =>
            {
                var assemblies = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")
                .Select(assembly
                    => Assembly.Load(AssemblyName.GetAssemblyName(assembly)));

                configuration.RegisterServicesFromAssemblies(assemblies.ToArray());
            });
    }
}