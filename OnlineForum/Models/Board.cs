using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineForum.Models
{
    public class Board
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Thread> Threads { get; set; } = new List<Thread>();
    }
}
