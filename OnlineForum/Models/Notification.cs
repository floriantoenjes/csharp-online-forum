using System;

namespace OnlineForum.Models
{
    public class Notification : IHasCreatedAt
    {
        public int Id { get; set; }
        
        public int ReceiverId { get; set; }
        
        public User Receiver { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public NotificationType NotificationType { get; set; }
        
        public int TypeIdentifier { get; set; }
        
    }

    public enum NotificationType
    {
        NewPost,
        PrivateMessage
    }
}