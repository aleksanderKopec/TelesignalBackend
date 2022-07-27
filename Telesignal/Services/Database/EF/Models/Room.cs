namespace Telesignal.Services.Database.EF.Models
{
    public class Room : DatabaseEntity
    {
    public int Id { get; set; }
    public string Name { get; set; }
    public List<User> Users { get; set; }
    public List<Message> Messages { get; set; }
    }
}
