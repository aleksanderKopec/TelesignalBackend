using Microsoft.AspNetCore.SignalR;

namespace Telesignal.Chat;

public class ChatHub : Hub
{
    public async Task SendMessage(string user, string message) {
        await Clients.AllExcept(user).SendAsync("ReceiveMessage", user, message);
    }
}
