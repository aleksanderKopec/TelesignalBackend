namespace Telesignal.Common.Database.EntityFramework.Model
{
    public class Profile : DatabaseEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Bio { get; set; }
        public Uri? ProfilePictureUri { get; set; }
    }
}
