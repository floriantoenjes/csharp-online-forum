using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineForum.Models
{
    public class Board
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Thread> Threads { get; set; } = new List<Thread>();
        
        public int? LastThreadId { get; set; }
        
        public Thread LastThread { get; set; }
        
        public int ThreadCount { get; set; }
    }
}
