using Telesignal.Common.Database.EntityFramework.Model;

namespace Telesignal.Sample.Interfaces;

public interface ISampleService
{
    public Task<User> GetUser(string id);
}
