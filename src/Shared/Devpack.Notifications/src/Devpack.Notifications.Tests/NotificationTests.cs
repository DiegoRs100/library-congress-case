using Bogus;
using FluentAssertions;
using System;
using System.Net;
using Xunit;

namespace Devpack.Notifications.Tests
{
    public class NotificationTests
    {
        [Fact(DisplayName = "Deve inicializar as proriedades básicas quando o construtor for chamado apenas contendo a mensagem de erro.")]
        [Trait("Category", "Entities")]
        public void Constructor_Base()
        {
            var faker = new Faker();
            var message = faker.Random.Words(5);
            var statusCode = faker.Random.Enum<HttpStatusCode>();

            var notification = new Notification(message, statusCode);

            notification.Message.Should().Be(message);
            notification.NotificationType.Should().Be(statusCode);
        }

        [Fact(DisplayName = "Deve inicializar a propriedade (ErrorCode) quando o construtor for chamado passando um código de erro.")]
        [Trait("Category", "Entities")]
        public void Constructor_WithErrorCode()
        {
            var faker = new Faker();
            var errorCode = Guid.NewGuid().ToString();
            var message = faker.Random.Words(5);
            var statusCode = faker.Random.Enum<HttpStatusCode>();

            var notification = new Notification(errorCode, message, statusCode);

            notification.ErrorCode.Should().Be(errorCode);
            notification.Message.Should().Be(message);
            notification.NotificationType.Should().Be(statusCode);
        }

        [Fact(DisplayName = "Deve inicializar a propriedade (Field) quando o construtor for chamado passando um nome de campo.")]
        [Trait("Category", "Entities")]
        public void Constructor_WithField()
        {
            var faker = new Faker();
            var field = faker.Random.Word();
            var errorCode = Guid.NewGuid().ToString();
            var message = faker.Random.Words(5);
            var statusCode = faker.Random.Enum<HttpStatusCode>();

            var notification = new Notification(errorCode, field, message, statusCode);

            notification.Field.Should().Be(field);
            notification.ErrorCode.Should().Be(errorCode);
            notification.Message.Should().Be(message);
            notification.NotificationType.Should().Be(statusCode);
        }
    }
}