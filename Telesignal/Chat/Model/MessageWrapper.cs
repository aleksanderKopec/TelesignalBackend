using Telesignal.Chat.Model.Message;
using DatabaseModel = Telesignal.Common.Database.EntityFramework.Model;

namespace Telesignal.Chat.Model;

public class MessageWrapper
{

    public string AuthorName { get; set; } = string.Empty;
    public string AuthorId { get; set; } = string.Empty;
    public string RoomId { get; set; } = string.Empty;
    public string EncryptedMessage { get; set; } = string.Empty;
    public KeyMap KeyMap { get; set; } = new();

    public override string ToString() {
        return $"AuthorId: {AuthorId}" +
               $"RoomId: {RoomId}" +
               $"EncryptedMessage: ${EncryptedMessage}" +
               $"KeyMap: ${KeyMap}";
    }
}
