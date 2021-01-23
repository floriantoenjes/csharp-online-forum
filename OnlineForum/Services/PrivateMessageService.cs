using OnlineForum.Data;
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

        public void sendPrivateMessage(int recipientId, PrivateMessage privateMessage)
        {
            privateMessage.RecipientId = recipientId;
            _privateMessageRepository.Add(privateMessage);
        }
    }
}