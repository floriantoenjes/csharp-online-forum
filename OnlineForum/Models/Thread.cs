using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineForum.Models
{
    public class Thread : IHasCreatedAt
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int CreatorId { get; set; }

        public User Creator { get; set; }

        public int BoardId { get; set; }

        public Board Board { get; set; }
        
        public Board LastThreadOn { get; set; }

        public ICollection<Post> Posts { get; set; } = new List<Post>();

        public DateTime CreatedAt { get; set; }

        public ICollection<User> Subscribers { get; set; } = new List<User>();

        public int PostCount { get; set; }
    }
}
