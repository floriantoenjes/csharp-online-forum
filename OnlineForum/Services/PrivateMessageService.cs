using System.Collections.Generic;
using OnlineForum.Data;
using OnlineForum.Models;

namespace OnlineForum.Services
{
    public class PrivateMessageService
    {
        private readonly IPrivateMessageRepository _privateMessageRepository;

        public PrivateMessageService(IPrivateMessageRepository privateMessageRepository)
        {
            _privateMessageRepository = privateMessageRepository;
        }

        public void SendPrivateMessage(int senderId, int recipientId, PrivateMessage privateMessage)
        {
            if (senderId == recipientId)
            {
                return;
            }
            
            privateMessage.SenderId = senderId;
            privateMessage.RecipientId = recipientId;
            _privateMessageRepository.Add(privateMessage);
        }

        public IList<PrivateMessage> GetPrivateMessagesByUserId(int currentUserId)
        {
            return _privateMessageRepository.GetPrivateMessagesByUserId(currentUserId);
        }
    }
}