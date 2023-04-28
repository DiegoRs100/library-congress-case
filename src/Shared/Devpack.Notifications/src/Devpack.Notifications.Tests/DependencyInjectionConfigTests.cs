using FluentAssertions;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Devpack.Notifications.Notifier;
using Moq;
using Microsoft.Extensions.Logging;
using NotifierService = Devpack.Notifications.Notifier.Notifier;
using MediatR;

namespace Devpack.Notifications.Tests
{
    public class DependencyInjectionConfigTests
    {
        [Fact(DisplayName = "Deve injetar corretamente o notificador quando o método for chamado.")]
        [Trait("Category", "Extesions")]
        public void AddSmartNotification()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped(_ => new Mock<ILogger<NotifierService>>().Object);
            serviceCollection.AddSmartNotification();

            var provider = serviceCollection.BuildServiceProvider();
            var notifier = provider.GetService<INotifier>();
            var notificationHandler = provider.GetService<INotificationHandler<Notification>>();

            notifier.Should().NotBeNull();
            notificationHandler.Should().NotBeNull();
        }
    }
}