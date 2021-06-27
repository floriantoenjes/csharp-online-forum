using System.Collections.Generic;
using OnlineForum.Models;

namespace OnlineForum.Data
{
    public interface IPrivateMessageRepository : IBaseRepository<PrivateMessage>
    {
        IList<PrivateMessage> GetPrivateMessagesByUserId(int userId);

        IList<PrivateMessage> GetConversation(int currentUserId, int otherUserId);
        
    }
}