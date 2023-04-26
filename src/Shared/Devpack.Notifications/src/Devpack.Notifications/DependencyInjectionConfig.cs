using Devpack.Notifications.Notifier;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NotifierService = Devpack.Notifications.Notifier.Notifier;

namespace Devpack.Notifications
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddSmartNotification(this IServiceCollection service)
        {
            service.AddScoped<INotifier, NotifierService>();
            service.AddScoped<INotificationHandler<Notification>, NotificationHandler>();

            return service;
        }
    }
}