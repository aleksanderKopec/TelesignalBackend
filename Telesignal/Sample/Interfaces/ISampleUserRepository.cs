using Telesignal.Common.Database.EntityFramework.Model;
using Telesignal.Common.Interfaces;

namespace Telesignal.Sample.Interfaces
{
    public interface ISampleUserRepository : IRepository<User>
    {
    }
}