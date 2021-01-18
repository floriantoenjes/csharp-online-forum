using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineForum.Models
{
    public class Thread
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CreatorId { get; set; }

        public User Creator { get; set; }

        public int BoardId { get; set; }

        public Board Board { get; set; }

        public ICollection<Post> Posts { get; set; } = new List<Post>();

        public DateTime CreatedAt { get; set; }

        public ICollection<UserSettings> Subscribers { get; set; }
    }
}
