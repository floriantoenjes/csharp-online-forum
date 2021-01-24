using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineForum.Models
{
    public class Post : IHasCreatedAt
    {
        public int Id { get; set; }
        
        [Required]
        public string Content { get; set; }

        public int CreatorId { get; set; }

        public User Creator { get; set; }

        public int ThreadId { get; set; }

        public Thread Thread { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
