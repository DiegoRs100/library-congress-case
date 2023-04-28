using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Devpack.Notifications.Notifier
{
    public class Notifier : INotifier
    {
        private readonly ILogger<Notifier> _logger;
        private readonly NotificationHandler _messageHandler;

        public bool HasNotifications => _messageHandler.HasNotifications();

        public Notifier(ILogger<Notifier> logger, INotificationHandler<Notification> notification)
        {
            _logger = logger;
            _messageHandler = (NotificationHandler)notification;
        }

        public IReadOnlyCollection<Notification> GetNotifications()
        {
            return _messageHandler.GetNotifications();
        }

        public Task NotifyAsync(string message, HttpStatusCode notificationType = HttpStatusCode.UnprocessableEntity)
        {
            if (message.IsNullOrWhiteSpace())
                return Task.CompletedTask;

            _logger.LogInformation("Notified: {message}", message);
            return _messageHandler.Handle(new Notification(message, notificationType), default);
        }

        public Task NotifyAsync(string errorCode, string message, HttpStatusCode notificationType = HttpStatusCode.UnprocessableEntity)
        {
            if (message.IsNullOrWhiteSpace())
                return Task.CompletedTask;

            _logger.LogInformation("Notified: {message}", message);
            return _messageHandler.Handle(new Notification(errorCode, message, notificationType), default);
        }

        public Task NotifyAsync(string errorCode, string field, string message, HttpStatusCode notificationType = HttpStatusCode.UnprocessableEntity)
        {
            if (message.IsNullOrWhiteSpace())
                return Task.CompletedTask;

            _logger.LogInformation("Notified: {message}", message);
            return _messageHandler.Handle(new Notification(errorCode, field, message, notificationType), default);
        }

        public async Task NotifyAsync(ValidationResult validationResult, HttpStatusCode notificationType = HttpStatusCode.UnprocessableEntity)
        {
            foreach (var error in validationResult.Errors)
            {
                _logger.LogInformation("Notified: {message}", error.ErrorMessage);
                await _messageHandler.Handle(new Notification(error.ErrorCode, error.PropertyName, error.ErrorMessage, notificationType), default);
            }
        }

        public JsonResult GetAsJsonResult()
        {
            if (!HasNotifications)
                return new JsonResult(null) { StatusCode = (int)HttpStatusCode.UnprocessableEntity };

            return new JsonResult(new NotificationsModel(GetNotifications()))
            {
                StatusCode = (int)_messageHandler.NotificationsType!
            };
        }
    }
}