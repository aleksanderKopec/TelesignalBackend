using Telesignal.Chat.Model.Message;
using DatabaseModel = Telesignal.Common.Database.EntityFramework.Model;

namespace Telesignal.Chat.Model;

public class MessageWrapper
{
    public int AuthorId { get; set; } = -1;
    public int RoomId { get; set; } = -1;
    public MessageContent MessageContent { get; set; } = new();
}
