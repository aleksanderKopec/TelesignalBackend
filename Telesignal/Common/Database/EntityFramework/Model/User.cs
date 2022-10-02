using Microsoft.AspNetCore.Identity;

namespace Telesignal.Common.Database.EntityFramework.Model;

public class User : IdentityUser<int>, DatabaseEntity
{
    /// <summary>
    ///     Email of user.
    /// </summary>
    public Email Email { get; set; }
    /// <summary>
    ///     Hashed password
    /// </summary>
    public string Password { get; set; }
    /// <summary>
    ///     Profile of user. Contains user given information.
    /// </summary>
    public Profile Profile { get; set; }
    /// <summary>
    ///     List of contacts (friends) of given user.
    /// </summary>
    public List<User> Contacts { get; set; }
}
