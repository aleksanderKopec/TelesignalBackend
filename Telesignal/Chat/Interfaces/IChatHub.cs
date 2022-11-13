namespace Telesignal.Chat.Interfaces;

public interface IChatHub
{
    Task SendMessage(string user, string message);
}
