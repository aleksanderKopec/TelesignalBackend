using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Telesignal.Common.Database.EntityFramework.Model;

[Index(nameof(DateAdded))]
public class Message : IDatabaseEntity
{

    public int Id { get; init; }
    /// <summary>
    ///     Author of the message.
    /// </summary>
    public User Author { get; init; } = new();
    /// <summary>
    ///     Room in which message has been send.
    /// </summary>
    public Room Room { get; init; } = new();
    /// <summary>
    ///     Hashed and encrypted content of message.
    /// </summary>
    public string Content { get; set; } = string.Empty;

    [Column(TypeName = "datetime2")] public DateTime DateAdded { get; set; } = DateTime.Now;

    public string KeyMapJson { get; set; } = string.Empty;
}
