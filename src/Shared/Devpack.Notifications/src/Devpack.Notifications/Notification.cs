using MediatR;
using System.Net;
using System.Text.Json.Serialization;

namespace Devpack.Notifications
{
    public class Notification : INotification
    {
        public string Message { get; }
        public string ErrorCode { get; } = default!;

        [JsonIgnore]
        public string Field { get; } = default!;

        [JsonIgnore]
        public HttpStatusCode NotificationType { get; }

        public Notification(string message, HttpStatusCode notificationType)
        {
            Message = message;
            NotificationType = notificationType;
        }

        public Notification(string errorCode, string message, HttpStatusCode notificationType)
            : this(message, notificationType)
        {
            ErrorCode = errorCode;
        }

        public Notification(string errorCode, string field, string message, HttpStatusCode notificationType)
            : this(errorCode, message, notificationType)
        {
            Field = field;
        }
    }
}