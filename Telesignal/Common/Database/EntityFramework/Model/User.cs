using Microsoft.EntityFrameworkCore;

namespace Telesignal.Common.Database.EntityFramework.Model;

[Index(nameof(Username), IsUnique = true)]
public class User : IDatabaseEntity
{
    public int Id { get; set; }

    public string Username { get; set; } = string.Empty;
    /// <summary>
    ///     Email information of user.
    /// </summary>
    public Email Email { get; set; } = new();
    /// <summary>
    ///     Hashed password
    /// </summary>
    public string PasswordHash { get; set; } = string.Empty;
    /// <summary>
    ///     Profile of user. Contains user given information.
    /// </summary>
    public Profile Profile { get; set; } = new();
    /// <summary>
    ///     List of contacts (friends) of given user.
    /// </summary>
    public List<User> Contacts { get; set; } = new();
    public List<Room> AdminOf { get; set; } = new();
    public List<Room> MemberOf { get; set; } = new();
}
