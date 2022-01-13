
namespace Domain.Helpers
{
    public class Notificator : INotificator
    {
        private List<Notification> _notification;

        public Notificator()
        {
            _notification = new List<Notification>();
        }

        public void Handle(Notification notification)
        {
            _notification.Add(notification);
        }

        public List<Notification> GetNotifications()
        {
            return _notification;
        }

        public bool HasNotification()
        {
            return _notification.Any();
        }
    }
}
