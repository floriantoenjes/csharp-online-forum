using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace OnlineForum.Models
{
    public class User : IdentityUser<int>
    {
        public string Signature { get; set; }

        public ICollection<Thread> Threads { get; set; } = new List<Thread>();
        
        public ICollection<Thread> Subscriptions { get; set; } = new List<Thread>();

        public ICollection<Post> Posts { get; set; } = new List<Post>();

        public int PostCount { get; set; }

        public int Reputation { get; set; }

        public ICollection<PrivateMessage> MessagesSent { get; set; } = new List<PrivateMessage>();

        public ICollection<PrivateMessage> MessagesReceived { get; set; } = new List<PrivateMessage>();

        public DateTime LastSeen { get; set; }

        public DateTime JoinedAt { get; set; }
        
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    }
}
