using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineForum.Models
{
    public class PrivateMessage : IHasCreatedAt
    {
        public int Id { get; set; }

        public int SenderId { get; set; }

        public User Sender { get; set; }

        public int RecipientId { get; set; }

        public User Recipient { get; set; }

        [StringLength(3)]
        public string Subject { get; set; }
        
        [StringLength(5)]
        public string Body { get; set; }

        public DateTime SentAt { get; set; }

        [NotMapped]
        public DateTime CreatedAt
        {
            get => SentAt;

            set => SentAt = value;
        }
    }
}
