using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using OnlineForum.Models;

namespace OnlineForum.SignalR
{
    public class NotificationHub : Hub
    {
        public async Task Notify(NotificationType type)
        {
            await Clients.All.SendAsync("ReceiveMessage", type);
        }
    }
}