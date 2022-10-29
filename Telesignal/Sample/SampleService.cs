using Telesignal.Common.Database.EntityFramework.Model;
using Telesignal.Sample.Interfaces;

namespace Telesignal.Sample;

public class SampleService : ISampleService
{
    readonly private ISampleUserRepository _userRepository;

    public SampleService(ISampleUserRepository repository) {
        _userRepository = repository;
    }

    public async Task<User> GetUser(string id) {
        return await _userRepository.Find(id);
    }
}
