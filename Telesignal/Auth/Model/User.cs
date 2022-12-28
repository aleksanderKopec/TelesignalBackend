using Telesignal.Common.Interfaces;
using DatabaseModel = Telesignal.Common.Database.EntityFramework.Model;

namespace Telesignal.Auth.Model;

public class User : ISaveable<User, DatabaseModel.User>
{
    public User(string username, Email email, string passwordHash) {
        Username = username;
        Email = email;
        PasswordHash = passwordHash;
    }
    public string Username { get; set; }
    public Email Email { get; set; }
    public string PasswordHash { get; set; }

    public DatabaseModel.User ToModel() {
        return new DatabaseModel.User {
            Username = Username,
            PasswordHash = PasswordHash,
            Email = Email.ToModel()
        };
    }

    public static User FromModel(DatabaseModel.User model) {
        return new User(model.Username, Email.FromModel(model.Email), model.PasswordHash);
    }
}
