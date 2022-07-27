namespace Telesignal.Services.Database.EF.Models
{
    public class Profile : DatabaseEntity
    {
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Bio { get; set; }
    public Uri? ProfilePictureUri { get; set; }
    }
}
