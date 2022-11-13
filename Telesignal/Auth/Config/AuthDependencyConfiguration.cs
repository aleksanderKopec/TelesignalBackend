using Microsoft.AspNetCore.Identity;
using Telesignal.Auth.Interfaces;
using Telesignal.Auth.Interfaces.Utils;
using Telesignal.Auth.Utils;
using Telesignal.Common.Database.EntityFramework.Model;

namespace Telesignal.Auth.Config;

public static class AuthDependencyConfiguration
{
    public static void AddDependencies(IServiceCollection services) {
        services.AddScoped<IAuthUserRepository, AuthUserRepository>();
        services.AddScoped<IAuthController, AuthController>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IEmailHasher, EmailHasher>();
        services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
        services.AddScoped<IJwtUtils, JwtUtils>();
    }
}
