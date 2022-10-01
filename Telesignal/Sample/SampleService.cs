using Telesignal.Sample.Interfaces;

namespace Telesignal.Sample;

public class SampleService : ISampleService
{
    readonly private ISampleUserRepository _userRepository;

    public SampleService(ISampleUserRepository repository) {
        _userRepository = repository;
    }

    public string ReturnBack(string input) {
        return input;
    }
}
