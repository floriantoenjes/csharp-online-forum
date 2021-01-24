﻿using OnlineForum.Data;
using OnlineForum.Models;

namespace OnlineForum.Services
{
    public class PrivateMessageService
    {
        private readonly IBaseRepository<PrivateMessage> _privateMessageRepository;

        public PrivateMessageService(IBaseRepository<PrivateMessage> privateMessageRepository)
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
    }
}