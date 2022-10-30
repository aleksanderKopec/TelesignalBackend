namespace Telesignal.Common.Config;

public static class ConfigDependencyConfiguration
{
    public static void AddDependencies(IServiceCollection services) {
        services.AddScoped<JwtConfig, JwtConfig>();
    }
}
