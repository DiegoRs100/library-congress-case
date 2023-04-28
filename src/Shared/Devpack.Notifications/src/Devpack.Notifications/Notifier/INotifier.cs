using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Devpack.Notifications.Notifier
{
    public interface INotifier
    {
        bool HasNotifications { get; }
        IReadOnlyCollection<Notification> GetNotifications();
        Task NotifyAsync(string message, HttpStatusCode notificationType = HttpStatusCode.UnprocessableEntity);
        Task NotifyAsync(string errorCode, string message, HttpStatusCode notificationType = HttpStatusCode.UnprocessableEntity);
        Task NotifyAsync(string errorCode, string field, string message, HttpStatusCode notificationType = HttpStatusCode.UnprocessableEntity);
        Task NotifyAsync(ValidationResult validationResult, HttpStatusCode notificationType = HttpStatusCode.UnprocessableEntity);
        JsonResult GetAsJsonResult();
    }
}