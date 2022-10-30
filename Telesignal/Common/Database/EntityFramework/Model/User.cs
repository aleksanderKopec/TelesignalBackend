using Microsoft.EntityFrameworkCore;

namespace Telesignal.Common.Database.EntityFramework.Model;

public class User : IDatabaseEntity
{
    public string Id { get; set; }

    [Index(IsUnique = true)] public string Username { get; set; }
    /// <summary>
    ///     Email information of user.
    /// </summary>
    public Email Email { get; set; }
    /// <summary>
    ///     Hashed password
    /// </summary>
    public string PasswordHash { get; set; }
    /// <summary>
    ///     Profile of user. Contains user given information.
    /// </summary>
    public Profile Profile { get; set; }
    /// <summary>
    ///     List of contacts (friends) of given user.
    /// </summary>
    public List<User> Contacts { get; set; }
}
