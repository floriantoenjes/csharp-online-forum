using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineForum.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Signature { get; set; }

        public ICollection<Thread> Threads { get; set; } = new List<Thread>();

        public ICollection<Post> Posts { get; set; } = new List<Post>();

        public int PostCount { get; set; }

        public int Reputation { get; set; }

        public ICollection<PrivateMessage> MessagesSent { get; set; } = new List<PrivateMessage>();

        public ICollection<PrivateMessage> MessagesReceived { get; set; } = new List<PrivateMessage>();

        public Role RoleId { get; set; }

        public Role UserRole { get; set; }

        public UserSettings Settings { get; set; }

        public DateTime LastSeen { get; set; }

        public DateTime JoinedAt { get; set; }
    }
}
