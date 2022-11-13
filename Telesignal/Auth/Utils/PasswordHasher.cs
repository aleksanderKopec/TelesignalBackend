using Microsoft.AspNetCore.Identity;
using Telesignal.Auth.Interfaces.Utils;
using DatabaseModel = Telesignal.Common.Database.EntityFramework.Model;

namespace Telesignal.Auth.Utils;

public class PasswordHasher : IPasswordHasher
{
    readonly private static DatabaseModel.User DummyUser = new();

    readonly private IPasswordHasher<DatabaseModel.User> _passwordHasher;

    public PasswordHasher(IPasswordHasher<DatabaseModel.User> passwordHasher) {
        _passwordHasher = passwordHasher;
    }

    public string HashPassword(string password) {
        return _passwordHasher.HashPassword(DummyUser, password);
    }

    public bool CompareHash(string password, string hash) {
        return _passwordHasher.VerifyHashedPassword(DummyUser, hash, password) switch {
            PasswordVerificationResult.Failed => false,
            PasswordVerificationResult.Success => true,
            PasswordVerificationResult.SuccessRehashNeeded => true,
            _ => false
        };
    }
}
