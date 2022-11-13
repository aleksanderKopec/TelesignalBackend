namespace Telesignal.Auth.Interfaces.Utils;

public interface IPasswordHasher
{
    string HashPassword(string password);

    bool CompareHash(string password, string hash);
}
