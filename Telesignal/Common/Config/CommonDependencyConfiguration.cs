using Telesignal.Auth.Mappers;
using Telesignal.Common.Database.Repositories;
using Telesignal.Common.Database.Repositories.Interfaces;

namespace Telesignal.Common.Config;

public static class CommonDependencyConfiguration
{
    public static void AddDependencies(IServiceCollection services) {
        services.AddScoped<JwtConfig, JwtConfig>();
        services.AddAutoMapper(typeof(AuthUserMapperProfile));
        services.AddScoped<IMessageRepository, MessageRepository>();
        services.AddScoped<IRoomRepository, RoomRepository>();
        services.AddScoped<IProfileRepository, ProfileRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
    }
}
