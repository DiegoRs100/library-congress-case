using MediatR;
using System.Net;

namespace Devpack.Notifications
{
    public class NotificationHandler : INotificationHandler<Notification>
    {
        private readonly List<Notification> _notifications;

        // Apenas um tipo de notificação é válido por requisição.
        internal HttpStatusCode? NotificationsType { get; set; }

        public NotificationHandler()
        {
            _notifications = new List<Notification>();
        }

        public virtual Task Handle(Notification notification, CancellationToken cancellationToken)
        {
            ValidateNotification(notification);

            _notifications.Add(notification);
            return Task.CompletedTask;
        }

        public virtual List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public virtual bool HasNotifications()
        {
            return _notifications.Any();
        }

        private void ValidateNotification(Notification notification)
        {
            // A primeira notificação vai definir em qual status code as notificações serão devolvidas para o usuário.
            // A partir da primeira notificação, não poderão ser inseridas norificações com status code de retorno diferente da primeira.
            if (!_notifications.Any())
            {
                NotificationsType = notification.NotificationType;
                return;
            }

            if (NotificationsType != notification.NotificationType)
            {
                throw new InvalidOperationException("It is not allowed to notify two different types of notification in the same request.",
                    new Exception($"Identified Types: { NotificationsType!.GetDescription() } and {notification.NotificationType.GetDescription()}."));
            }
        }
    }
}