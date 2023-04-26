using Bogus;
using Devpack.Testability.Extensions;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;
using ValidationResult = FluentValidation.Results.ValidationResult;
using NotifierService = Devpack.Notifications.Notifier.Notifier;
using FluentValidation.Results;

namespace Devpack.Notifications.Tests
{
    public class NotifierTests
    {
        private readonly Mock<ILogger<NotifierService>> _loggerMock;
        private readonly NotificationHandler _messageHandler;

        public NotifierTests()
        {
            _loggerMock = new Mock<ILogger<NotifierService>>();
            _messageHandler = new NotificationHandler();
        }

        [Fact(DisplayName = "Deve retornar verdadeiro quando existirem notificações.")]
        [Trait("Category", "Services")]
        public void HasNotifications_BeTrue()
        {
            var notifier = new NotifierService(_loggerMock.Object, _messageHandler);
            notifier.Notify(Guid.NewGuid().ToString());

            notifier.HasNotifications.Should().BeTrue();
        }

        [Fact(DisplayName = "Deve retornar falso quando não existirem notificações.")]
        [Trait("Category", "Services")]
        public void HasNotifications_BeFalse()
        {
            var notifier = new NotifierService(_loggerMock.Object, _messageHandler);
            notifier.HasNotifications.Should().BeFalse();
        }

        [Fact(DisplayName = "Deve retornar as notificações quando existirem notificações.")]
        [Trait("Category", "Services")]
        public async Task GetNotifications()
        {
            var message = Guid.NewGuid().ToString();

            var notifier = new NotifierService(_loggerMock.Object, _messageHandler);
            await notifier.Notify(message);

            notifier.GetNotifications().Should().HaveCount(1)
                .And.Contain(n => n.Message == message);
        }

        [Theory(DisplayName = "Não deve realizar ações quando a mensagem for inválida - OnlyMessage.")]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        [Trait("Category", "Services")]
        public async Task Notify_Invalid_OnlyMessage(string message)
        {
            var notifier = new NotifierService(_loggerMock.Object, _messageHandler);
            await notifier.Notify(message);

            _loggerMock.VerifyLogHasCalled(LogLevel.Information, $"Notified: {message}", Times.Never);
            notifier.HasNotifications.Should().BeFalse();
        }

        [Fact(DisplayName = "Deve adicionar notificação quando a mensagem for válida - OnlyMessage.")]
        [Trait("Category", "Services")]
        public async Task Notify_Valid_OnlyMessage()
        {
            var faker = new Faker();
            var message = faker.Random.Words(10);
            var notificationType = faker.Random.Enum<HttpStatusCode>();

            var notifier = new NotifierService(_loggerMock.Object, _messageHandler);
            await notifier.Notify(message, notificationType);

            _loggerMock.VerifyLogHasCalled(LogLevel.Information, $"Notified: {message}", Times.Once);

            notifier.GetNotifications().Should().HaveCount(1)
                .And.Contain(n => n.Message == message && n.NotificationType == notificationType);
        }

        [Theory(DisplayName = "Não deve realizar ações quando a mensagem for inválida - ErrorCode + Message.")]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        [Trait("Category", "Services")]
        public async Task Notify_Invalid_ErroCodeAndMessage(string message)
        {
            var notifier = new NotifierService(_loggerMock.Object, _messageHandler);
            await notifier.Notify(Guid.NewGuid().ToString(), message);

            _loggerMock.VerifyLogHasCalled(LogLevel.Information, $"Notified: {message}", Times.Never);
            notifier.HasNotifications.Should().BeFalse();
        }

        [Fact(DisplayName = "Deve adicionar notificação quando a mensagem for válida - ErrorCode + Message.")]
        [Trait("Category", "Services")]
        public async Task Notify_Valid_ErroCodeAndMessage()
        {
            var faker = new Faker();
            var errorCode = Guid.NewGuid().ToString();
            var message = faker.Random.Words(10);
            var notificationType = faker.Random.Enum<HttpStatusCode>();

            var notifier = new NotifierService(_loggerMock.Object, _messageHandler);
            await notifier.Notify(errorCode, message, notificationType);

            _loggerMock.VerifyLogHasCalled(LogLevel.Information, $"Notified: {message}", Times.Once);

            notifier.GetNotifications().Should().HaveCount(1).And.Contain(n => 
                n.ErrorCode == errorCode 
                && n.Message == message 
                && n.NotificationType == notificationType);
        }

        [Theory(DisplayName = "Não deve realizar ações quando a mensagem for inválida - Field + ErrorCode + Message.")]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        [Trait("Category", "Services")]
        public async Task Notify_Invalid_FieldAndErroCodeAndMessage(string message)
        {
            var notifier = new NotifierService(_loggerMock.Object, _messageHandler);
            await notifier.Notify(Guid.NewGuid().ToString(), new Faker().Random.Word(), message);

            _loggerMock.VerifyLogHasCalled(LogLevel.Information, $"Notified: {message}", Times.Never);
            notifier.HasNotifications.Should().BeFalse();
        }

        [Fact(DisplayName = "Deve adicionar notificação quando a mensagem for válida - Field + ErrorCode + Message.")]
        [Trait("Category", "Services")]
        public async Task Notify_Valid_FieldAndErroCodeAndMessagee()
        {
            var faker = new Faker();

            var errorCode = Guid.NewGuid().ToString();
            var field = faker.Random.Word();
            var message = faker.Random.Words(10);
            var notificationType = faker.Random.Enum<HttpStatusCode>();

            var notifier = new NotifierService(_loggerMock.Object, _messageHandler);
            await notifier.Notify(errorCode, field, message, notificationType);

            _loggerMock.VerifyLogHasCalled(LogLevel.Information, $"Notified: {message}", Times.Once);

            notifier.GetNotifications().Should().HaveCount(1).And.Contain(n =>
                n.Field == field
                && n.ErrorCode == errorCode
                && n.Message == message
                && n.NotificationType == notificationType);
        }

        [Fact(DisplayName = "Deve adicionar notificação quando o (ValidationResult) contiver erros.")]
        [Trait("Category", "Services")]
        public async Task Notify_ValidationResult()
        {
            var faker = new Faker();
            var validationResult = new ValidationResult();
            var notificationType = faker.Random.Enum<HttpStatusCode>();

            validationResult.Errors.Add(new ValidationFailure()
            {
                ErrorCode = Guid.NewGuid().ToString(),
                PropertyName = faker.Random.Word(),
                ErrorMessage = faker.Random.Words(10)
            });

            validationResult.Errors.Add(new ValidationFailure()
            {
                ErrorCode = Guid.NewGuid().ToString(),
                PropertyName = faker.Random.Word(),
                ErrorMessage = faker.Random.Words(10)
            });

            var notifier = new NotifierService(_loggerMock.Object, _messageHandler);
            await notifier.Notify(validationResult, notificationType);

            _loggerMock.VerifyLogHasCalled(LogLevel.Information, $"Notified: {validationResult.Errors[0].ErrorMessage}", Times.Once);
            _loggerMock.VerifyLogHasCalled(LogLevel.Information, $"Notified: {validationResult.Errors[1].ErrorMessage}", Times.Once);

            notifier.GetNotifications().Should().HaveCount(2);

            notifier.GetNotifications().Should().Contain(n =>
                n.Field == validationResult.Errors[0].PropertyName
                && n.ErrorCode == validationResult.Errors[0].ErrorCode
                && n.Message == validationResult.Errors[0].ErrorMessage
                && n.NotificationType == notificationType);

            notifier.GetNotifications().Should().Contain(n =>
                n.Field == validationResult.Errors[1].PropertyName
                && n.ErrorCode == validationResult.Errors[1].ErrorCode
                && n.Message == validationResult.Errors[1].ErrorMessage
                && n.NotificationType == notificationType);
        }

        [Fact(DisplayName = "Deve retornar um JsonResult genérico quando não houverem notificações.")]
        [Trait("Category", "Services")]
        public void GetAsJsonResult_WhenNoHasNotifications()
        {
            var notifier = new NotifierService(_loggerMock.Object, _messageHandler);
            var result = notifier.GetAsJsonResult();

            result.Value.Should().BeNull();
            result.StatusCode.Should().Be((int)HttpStatusCode.UnprocessableEntity);
        }

        [Fact(DisplayName = "Deve retornar as notificações em um JsonResult quando houverem notificações.")]
        [Trait("Category", "Services")]
        public async Task GetAsJsonResult_WhenHasNotifications()
        {
            var faker = new Faker();
            var message = faker.Random.Words(10);
            var notificationType = faker.Random.Enum<HttpStatusCode>();

            var notifier = new NotifierService(_loggerMock.Object, _messageHandler);
            await notifier.Notify(message, notificationType);

            var expectedResultModel = new NotificationsModel(notifier.GetNotifications());

            var result = notifier.GetAsJsonResult();

            result.Value.Should().BeEquivalentTo(expectedResultModel);
            result.StatusCode.Should().Be((int)notificationType);
        }
    }
}