using Telesignal.Sample.Interfaces;

namespace Telesignal.Sample.Config;

public static class SampleDependencyConfiguration
{
    public static void AddDependencies(IServiceCollection services) {
        services.AddScoped<ISampleController, SampleController>();
        services.AddScoped<ISampleService, SampleService>();
        services.AddScoped<ISampleUserRepository, SampleUserRepository>();
    }
}
