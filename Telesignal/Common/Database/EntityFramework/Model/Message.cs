namespace Telesignal.Common.Database.EntityFramework.Model;

public class Message : IDatabaseEntity
{

    public int Id { get; init; }
    /// <summary>
    ///     Author of the message.
    /// </summary>
    public User Author { get; init; }
    /// <summary>
    ///     Room in which message has been send.
    /// </summary>
    public Room Room { get; init; }
    /// <summary>
    ///     Hashed and encrypted content of message.
    /// </summary>
    public string Content { get; set; }
}
