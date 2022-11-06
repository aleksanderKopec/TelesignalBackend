using Microsoft.EntityFrameworkCore;

namespace Telesignal.Common.Database.EntityFramework.Model;

/// <summary>
///     Object containing database structure of emails.
/// </summary>
[Index(nameof(Hash), IsUnique = true)]
public class Email : IDatabaseEntity
{
    public int Id { get; set; }
    /// <summary>
    ///     Hash of email.
    /// </summary>
    public string Hash { get; set; }
    /// <summary>
    ///     Domain in which email is registered.
    /// </summary>
    public string Domain { get; set; }
    /// <summary>
    ///     First 3 letters of email.
    /// </summary>
    public string Prefix { get; set; }
}
