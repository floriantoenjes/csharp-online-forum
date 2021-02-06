using System.Collections.Generic;
using System.Linq;
using OnlineForum.Models;

namespace OnlineForum.Data
{
    public class NotificationRepository : BaseRepository<Context, Notification>, INotificationRepository
    {
        public NotificationRepository(Context context) : base(context)
        {
        }

        public override Notification Get(int id)
        {
            return Context.Notifications.Find(id);
        }

        public override IList<Notification> GetList()
        {
            return Context.Notifications.ToList();
        }

        public IList<Notification> GetNotificationsByUserId(int userId)
        {
            return Context.Notifications.Where(n => n.Receivers.Any(r => r.Id == userId)).ToList();
        }
    }
}