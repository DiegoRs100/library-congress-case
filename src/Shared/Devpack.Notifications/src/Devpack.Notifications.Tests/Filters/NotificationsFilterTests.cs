using Devpack.Notifications.Filters;
using Devpack.Notifications.Notifier;
using Devpack.Notifications.Tests.Common;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;
using NotifierEntity = Devpack.Notifications.Notifier.Notifier;

namespace Devpack.Notifications.Tests.Filters
{
    public class NotificationsFilterTests
    {
        private readonly Mock<INotifier> _notifierMock;
        private readonly Mock<ILogger<NotifierEntity>> _loggerMock;

        public NotificationsFilterTests()
        {
            _notifierMock = new Mock<INotifier>();
            _loggerMock = new Mock<ILogger<NotifierEntity>>();
        }

        [Fact(DisplayName = "Deve finalizar o filter sem qualquer ação quando o notifier não possuir notificações")]
        [Trait("Category", "Filters")]
        public void OnActionExecuting_WhenNoHasNotifications()
        {
            var actionExecutingContext = FilterContextFactory.CreateContext();
            var filter = new NotificationsFilter(_notifierMock.Object);

            filter.OnActionExecuting(actionExecutingContext);

            actionExecutingContext.Result.Should().BeNull();
        }

        [Fact(DisplayName = "Deve ajustar o resultado da requisição para JsonResult quando houverem notificações no notifier.")]
        [Trait("Category", "Filters")]
        public void OnActionExecuting_WhenHasNotifications()
        {
            // Arrange
            var notifier = new NotifierEntity(_loggerMock.Object, new NotificationHandler());
            notifier.Notify(Guid.NewGuid().ToString());

            var actionExecutingContext = FilterContextFactory.CreateContext();
            var filter = new NotificationsFilter(notifier);

            // Act
            filter.OnActionExecuting(actionExecutingContext);

            // Asserts
            actionExecutingContext.Result.Should().BeEquivalentTo(notifier.GetAsJsonResult());
        }
    }
}