using Microsoft.AspNetCore.SignalR;
using Serilog;

namespace Telesignal.Chat;

public class ChatHub : Hub
{
    public async Task SendMessage(string user, string message) {
        Log.Information($"User: {user}, message: {message}");
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}
