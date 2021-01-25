using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using OnlineForum.Data;
using OnlineForum.Models;
using OnlineForum.SignalR;

namespace OnlineForum.Services
{
    public class NotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationService(INotificationRepository notificationRepository, IHubContext<NotificationHub> hubContext)
        {
            _notificationRepository = notificationRepository;
            _hubContext = hubContext;
        }

        public IList<Notification> GetNotificationsForUser(int userId)
        {
            return _notificationRepository.GetNotificationsByUserId(userId);
        }

        public void CreateNotification(int receiverId, NotificationType notificationType, int typeId)
        {
            var newNotification = new Notification
                {ReceiverId = receiverId, NotificationType = notificationType, TypeIdentifier = typeId};

            _notificationRepository.Add(newNotification);

            _hubContext.Clients.All.SendAsync("ReceiveMessage", "Ja man!");
        }
    }
    
}