using Telesignal.Auth.Model;
using DatabaseModel = Telesignal.Common.Database.EntityFramework.Model;

namespace Telesignal.Auth.Interfaces;

public interface IAuthUserRepository
{
    Task<bool> AddUser(DatabaseModel.User databaseUser);

    Task<bool> AddUser(User authUser);

    Task<DatabaseModel.User?> FindUserByName(string username);
}
