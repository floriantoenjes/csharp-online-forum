using System;
using System.Collections.Generic;

namespace OnlineForum.Models
{
    public class Notification : IHasCreatedAt
    {
        public int Id { get; set; }
        
        public ICollection<User> Receivers { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public DateTime? ReadAt { get; set; }
        
        public NotificationType NotificationType { get; set; }
        
        public int TypeIdentifier { get; set; }
        
    }

    public enum NotificationType
    {
        NewPost,
        PrivateMessage
    }
}