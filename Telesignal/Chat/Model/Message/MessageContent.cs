namespace Telesignal.Chat.Model.Message;

public class MessageContent
{
    public KeyMap KeyMap { get; set; } = new();
    public string Value { get; set; } = string.Empty;
}
