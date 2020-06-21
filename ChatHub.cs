using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalRSimpleChat.Services;

namespace SignalRSimpleChat
{
    public class Chat : Hub
    {
        IChatService chatService;
        public Chat(IChatService service)
        {
            chatService = service;
        }
        public async Task Send(string nick, string message)
        {
            await Clients.All.SendAsync("Send", nick, message);
            await chatService.SaveChat(nick, message);
        }
    }
}
