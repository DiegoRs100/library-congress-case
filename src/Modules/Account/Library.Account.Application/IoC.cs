using Library.Account.Application.Visitors.Services;
using Library.Account.Domain.Users;
using Library.Account.Domain.Users.Services;
using Library.Account.Domain.Visitors.Repositories;
using Library.Account.Domain.Visitors.Services;
using Library.Account.Infra.Repositories;
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

            services.AddScoped<IVisitorRepository, VisitorRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}