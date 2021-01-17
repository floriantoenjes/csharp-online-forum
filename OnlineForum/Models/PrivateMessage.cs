using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineForum.Models
{
    public class PrivateMessage
    {
        public int Id { get; set; }

        public User Sender { get; set; }

        public User Recipient { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public DateTime SentAt { get; set; }
    }
}
