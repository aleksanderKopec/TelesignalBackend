using Microsoft.AspNetCore.Identity;
using Telesignal.Auth.Interfaces.Utils;
using Telesignal.Auth.Model;
using DatabaseModel = Telesignal.Common.Database.EntityFramework.Model;

namespace Telesignal.Auth.Utils;

public class EmailHasher : IEmailHasher
{
    readonly private static DatabaseModel.User DummyUser = new();

    readonly private IPasswordHasher<DatabaseModel.User> _emailHasher;

    public EmailHasher(IPasswordHasher<DatabaseModel.User> emailHasher) {
        _emailHasher = emailHasher;
    }

    public Email HashEmail(string email) {
        // User is not used in implementation, so passing it as a dummy is OK (probably).
        var emailHash = _emailHasher.HashPassword(DummyUser, email);
        return Email.Parse(email, emailHash);
    }

    public bool CompareHash(Email email, string hash) {
        throw new NotImplementedException();
    }
}
