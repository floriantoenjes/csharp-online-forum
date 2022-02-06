using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineForum.Models;

namespace OnlineForum.Data
{
    public class PrivateMessageRepository : BaseRepository<Context, PrivateMessage>, IPrivateMessageRepository
    {
        public PrivateMessageRepository(Context context) : base(context)
        {
        }

        public override PrivateMessage Get(int id)
        {
            return Context.PrivateMessages.SingleOrDefault(pm => pm.Id == id);
        }

        public IList<PrivateMessage> GetPrivateMessagesByUserId(int userId)
        {
            return Context.PrivateMessages
                .Include(pm => pm.Sender)
                .Include(pm => pm.Recipient)
                .Where(pm => pm.SenderId == userId || pm.RecipientId == userId)
                .ToList().OrderByDescending(pm => pm.CreatedAt).ToList();
        }

        public IList<PrivateMessage> GetConversation(int currentUserId, int otherUserId)
        {
            var messagesSent = Context.PrivateMessages
                .Include(pm => pm.Sender)
                .Include(pm => pm.Recipient)
                .Where(pm => pm.SenderId == currentUserId && pm.RecipientId == otherUserId)
                .ToList();
            
            var messagesReceived = Context.PrivateMessages
                .Include(pm => pm.Sender)
                .Include(pm => pm.Recipient)
                .Where(pm => pm.SenderId == otherUserId && pm.RecipientId == currentUserId)
                .ToList();

            return messagesSent.Concat(messagesReceived).OrderByDescending(pm => pm.CreatedAt).ToList();
        }
    }
}