using Telesignal.Auth.Interfaces;
using Telesignal.Common.Database.EntityFramework;
using Telesignal.Common.Database.EntityFramework.Model;

namespace Telesignal.Auth;

public class AuthUserRepository : IAuthUserRepository
{
    readonly private DatabaseContext _databaseContext;

    public AuthUserRepository(DatabaseContext databaseContext) {
        _databaseContext = databaseContext;
    }

    public async Task<User> AddUser(User user) {
        return await from u in _databaseContext.Users
                     where u.Username == user.Username
    }
}
