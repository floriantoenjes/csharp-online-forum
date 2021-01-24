using System.Collections;
using System.Collections.Generic;
using OnlineForum.Data;
using OnlineForum.Models;

namespace OnlineForum.Services
{
    public class NotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public IList<Notification> GetNotificationsForUser(int userId)
        {
            return _notificationRepository.GetNotificationsByUserId(userId);
        }
    }
    
}