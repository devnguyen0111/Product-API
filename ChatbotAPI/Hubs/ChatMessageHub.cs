using Microsoft.AspNetCore.SignalR;

namespace ChatbotAPI.Hubs
{
    public class ChatMessageHub : Hub
    {

        public async Task SendMessageAsync(string userId, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", 0, "Test");
        }


    }
}
