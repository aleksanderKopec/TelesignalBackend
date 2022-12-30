using Microsoft.EntityFrameworkCore;

namespace Telesignal.Common.Database.EntityFramework.Model;

[Index(nameof(Name), IsUnique = true)]
public class Room : IDatabaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Message> Messages { get; set; } = new();

    public virtual List<User> Members { get; set; } = new();

    public virtual List<User> Admins { get; set; } = new();
}
