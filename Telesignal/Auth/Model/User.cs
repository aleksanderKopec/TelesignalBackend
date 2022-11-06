namespace Telesignal.Auth.Model;

public class User
{
    public User(string username, Email email, string passwordHash) {
        Username = username;
        Email = email;
        PasswordHash = passwordHash;
    }
    public string Username { get; set; }
    public Email Email { get; set; }
    public string PasswordHash { get; set; }
}
