using Library.Account.Application;

namespace Library.Api.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddAccountModule();
            return services;
        }
    }
}