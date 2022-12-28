using Telesignal.Common.Database.EntityFramework.Model;
using Telesignal.Common.Interfaces;

namespace Telesignal.Common.Database.Repositories.Interfaces;

public interface IUserRepository : IAsyncRepository<User>
{

    Task<User?> FindByUsername(string username);
}
