using Telesignal.Common.Database.EntityFramework.Model;

namespace Telesignal.Auth.Interfaces;

public interface IAuthUserRepository
{
    Task<User> AddUser(User user);
}
