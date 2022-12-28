using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Telesignal.Common.Database.EntityFramework.Model;

[Index(nameof(Name), IsUnique = true)]
public class Room : IDatabaseEntity
{
    public Room(int id, string name, User author) {
        Id = id;
        Name = name;
        Admins = new List<User> { author };
        Users = new List<User> { author };
    }
    public Room() {
    }
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    [ForeignKey("AdminsForeingKey")] public List<User> Admins { get; set; } = new();
    [ForeignKey("UsersForeingKey")] public List<User> Users { get; set; } = new();
    public List<Message> Messages { get; set; } = new();
}
