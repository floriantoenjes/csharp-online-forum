using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineForum.Models
{
    public class UserSettings
    {
        public int Id { get; set; }

        public ICollection<Thread> Subscriptions { get; set; } = new List<Thread>();
    }
}
