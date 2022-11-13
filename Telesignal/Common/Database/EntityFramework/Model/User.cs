using Microsoft.EntityFrameworkCore;

namespace Telesignal.Common.Database.EntityFramework.Model;

[Index(nameof(Username), IsUnique = true)]
public class User : IDatabaseEntity
{
    public int Id { get; set; }

    public string Username { get; set; } = "Username";
    /// <summary>
    ///     Email information of user.
    /// </summary>
    public Email Email { get; set; } = new();
    /// <summary>
    ///     Hashed password
    /// </summary>
    public string PasswordHash { get; set; } = "PasswordHash";
    /// <summary>
    ///     Profile of user. Contains user given information.
    /// </summary>
    public Profile Profile { get; set; } = new();
    /// <summary>
    ///     List of contacts (friends) of given user.
    /// </summary>
    public List<User> Contacts { get; set; } = new();
}
