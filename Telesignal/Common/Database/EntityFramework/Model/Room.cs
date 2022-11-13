namespace Telesignal.Common.Database.EntityFramework.Model;

public class Room : IDatabaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<User> Users { get; set; }
    public List<Message> Messages { get; set; }
}
