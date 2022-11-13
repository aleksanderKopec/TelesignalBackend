using Telesignal.Auth.Model;

namespace Telesignal.Auth.Interfaces.Utils;

public interface IEmailHasher
{
    Email HashEmail(string email);

    bool CompareHash(Email email, string hash);
}
