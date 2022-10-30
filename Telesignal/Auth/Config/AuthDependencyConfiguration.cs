using Telesignal.Auth.Interfaces;
using Telesignal.Sample.Interfaces;

namespace Telesignal.Auth.Config;

public static class AuthDependencyConfiguration
{
    public static void AddDependencies(IServiceCollection services) {
        services.AddScoped<IAuthController, AuthController>();
        services.AddScoped<IAuthService, AuthService>();
    }
}
