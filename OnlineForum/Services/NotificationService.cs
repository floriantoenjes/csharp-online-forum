using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            return _notificationRepository.GetNotificationsByUserId(userId).OrderByDescending(n => n.CreatedAt).ToList();
        }

        public void CreateNotification(ICollection<User> receivers, NotificationType notificationType, int typeId)
        {
            var newNotification = new Notification
            {
                Receivers = receivers, NotificationType = notificationType, TypeIdentifier = typeId
            };

            _notificationRepository.Add(newNotification);

            _hubContext.Clients.All.SendAsync("ReceiveMessage", "Ja man!");
        }

        public Notification MarkNotificationRead(int notificationId)
        {
            var notification = _notificationRepository.Get(notificationId);
            notification.ReadAt = DateTime.Now;
            _notificationRepository.Update(notification);

            return notification;
        }
    }
    
}