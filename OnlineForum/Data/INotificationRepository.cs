using System.Collections;
using System.Collections.Generic;
using OnlineForum.Models;

namespace OnlineForum.Data
{
    public interface INotificationRepository : IBaseRepository<Notification>
    {
        IList<Notification> GetNotificationsByUserId(int userId);
    }
}