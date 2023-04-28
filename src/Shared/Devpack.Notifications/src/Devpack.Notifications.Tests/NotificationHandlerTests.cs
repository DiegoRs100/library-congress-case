using Devpack.Extensions.Types;
using Devpack.Notifications;
using FluentAssertions;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Devpack.Notifications.Tests
{
    public class NotificationHandlerTests
    {
        // Testa consequentemente o método (GetNotifications())
        [Fact(DisplayName = "Deve capturar a notificação quando a mesma for a primeira notificação.")]
        [Trait("Category", "Handlers")]
        public async Task Handle_FirstNotification()
        {
            // Arrange
            var handler = new NotificationHandler();
            var notification = new Notification(Guid.NewGuid().ToString(), HttpStatusCode.UnprocessableEntity);

            // Act
            await handler.Handle(notification, new CancellationToken());

            // Asserts
            handler.GetNotifications().Should().HaveCount(1)
                .And.Contain(notification);
        }

        // Testa consequentemente o método (GetNotifications())
        [Fact(DisplayName = "Deve capturar a notificação quando a mesma for do mesmo tipo que a primeira notificação.")]
        [Trait("Category", "Handlers")]
        public async Task Handle_ValidNotification()
        {
            // Arrange
            var handler = new NotificationHandler();
            var notification1 = new Notification(Guid.NewGuid().ToString(), HttpStatusCode.UnprocessableEntity);
            var notification2 = new Notification(Guid.NewGuid().ToString(), HttpStatusCode.UnprocessableEntity);

            // Act
            await handler.Handle(notification1, new CancellationToken());
            await handler.Handle(notification2, new CancellationToken());

            // Asserts
            handler.GetNotifications().Should().HaveCount(2)
                .And.Contain(notification1)
                .And.Contain(notification2);
        }

        [Fact(DisplayName = "Deve lançar uma exeption quando a notificação for de um tipo tipo diferente da primeira notificação capturada.")]
        [Trait("Category", "Handlers")]
        public async Task Handle_InvalidNotification()
        {
            // Arrange
            var handler = new NotificationHandler();
            var notification1 = new Notification(Guid.NewGuid().ToString(), HttpStatusCode.BadRequest);
            var notification2 = new Notification(Guid.NewGuid().ToString(), HttpStatusCode.UnprocessableEntity);

            // Act
            await handler.Handle(notification1, new CancellationToken());

            // Asserts
            await handler.Invoking(h => h.Handle(notification2, new CancellationToken())).Should()
                .ThrowAsync<InvalidOperationException>()
                .WithMessage("It is not allowed to notify two different types of notification in the same request.")
                .WithInnerException(typeof(Exception))
                .WithMessage($"Identified Types: {HttpStatusCode.BadRequest.GetDescription()} and {HttpStatusCode.UnprocessableEntity.GetDescription()}.");
        }

        [Fact(DisplayName = "Deve retornar falso quando não existirem notificações.")]
        [Trait("Category", "Handlers")]
        public void HasNotifications_BeFalse()
        {
            var handler = new NotificationHandler();
            var result = handler.HasNotifications();

            result.Should().BeFalse();
        }

        [Fact(DisplayName = "Deve retornar verdadeiro quando existirem notificações.")]
        [Trait("Category", "Handlers")]
        public async Task HasNotifications_BeTrue()
        {
            var handler = new NotificationHandler();
            var notification = new Notification(Guid.NewGuid().ToString(), HttpStatusCode.UnprocessableEntity);

            await handler.Handle(notification, new CancellationToken());

            var result = handler.HasNotifications();
            result.Should().BeTrue();
        }
    }
}