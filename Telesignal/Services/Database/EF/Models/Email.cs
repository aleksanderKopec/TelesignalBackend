namespace Telesignal.Services.Database.EF.Models
{
/// <summary>
/// Object containing database structure of emails.
/// </summary>
    public class Email : DatabaseEntity
    {
    public int Id { get; set; }
    /// <summary>
    /// Hash of email.
    /// </summary>
    public string Hash { get; set; }
    /// <summary>
    /// Domain in which email is registered.
    /// </summary>
    public string Domain { get; set; }
    /// <summary>
    /// Last 3 letters before '@' in email.
    /// </summary>
    public string Suffix { get; set; }
    }
}
