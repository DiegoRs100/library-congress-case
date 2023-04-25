using Library.Account.Application;

namespace Library.Api.Config
{
    public static class IoC
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddAccountModule();
            return services;
        }
    }
}