using Library.Account.Application.Visitors.Services;
using Library.Account.Domain.Users.Services;
using Library.Account.Domain.Visitors.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Library.Account.Application
{
    public static class IoC
    {
        public static IServiceCollection AddAccountModule(this IServiceCollection services)
        {
            services.AddScoped<IVisitorAppService, VisitorAppService>();

            services.AddScoped<IVisitorService, VisitorService>();
            services.AddScoped<IUserService, UserService>();

            services.AddAutoMapper(typeof(AutoMapperConfig));

            return services;
        }
    }
}