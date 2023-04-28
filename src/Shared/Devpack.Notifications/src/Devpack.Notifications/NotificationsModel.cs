namespace Devpack.Notifications
{
    public class NotificationsModel
    {
        public IEnumerable<Notification> Core { get; set; }
        public Dictionary<string, IEnumerable<Notification>> Fields { get; set; }

        public NotificationsModel(IEnumerable<Notification> notifications)
        {
            Core = notifications.Where(n => n.Field.IsNullOrWhiteSpace());

            Fields = notifications
                .Where(n => !n.Field.IsNullOrWhiteSpace())
                .GroupBy(n => n.Field)
                .ToDictionary(g => g.Key, g => g.Select(v => v));
        }
    }
}