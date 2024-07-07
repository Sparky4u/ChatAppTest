using Microsoft.AspNetCore.SignalR;

namespace ChatAppTest.SignalR
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("Receive message", user, message);
        }
    }
}
