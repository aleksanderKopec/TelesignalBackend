namespace Telesignal.Chat.Model;

public record Room
{
    public int? RoomId { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
}
