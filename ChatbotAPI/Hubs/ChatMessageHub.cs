using Microsoft.AspNetCore.SignalR;

namespace ChatbotAPI.Hubs
{
    public class ChatMessageHub : Hub
    {

        public async Task SendMessageAsync(int userId, int chatBoxId, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", 0, "Test", -1, chatBoxId);
        }


    }
}
