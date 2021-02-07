using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace OnlineForum.SignalR
{
    public class NotificationHub : Hub
    {
        public async Task Notify(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}