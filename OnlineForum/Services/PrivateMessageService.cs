using System;
using System.Collections.Generic;
using System.Linq;
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

        public IDictionary<string, List<PrivateMessage>> GetConversationsByUserId(int currentUserId)
        {
            var privateMessages = _privateMessageRepository.GetPrivateMessagesByUserId(currentUserId);
            var conversations = new Dictionary<string, List<PrivateMessage>>();
            
            foreach (var privateMessage in privateMessages)
            {
                var senderId = privateMessage.SenderId;
                var recipientId = privateMessage.RecipientId;
                var conversationKey = Math.Min(senderId, recipientId) + "-" + Math.Max(senderId, recipientId);

                if (conversations.ContainsKey(conversationKey))
                {
                    conversations[conversationKey].Add(privateMessage);
                }
                else
                {
                    conversations.Add(conversationKey, new List<PrivateMessage>() { privateMessage });                    
                }

            }
            
            return conversations;
        }
    }
}