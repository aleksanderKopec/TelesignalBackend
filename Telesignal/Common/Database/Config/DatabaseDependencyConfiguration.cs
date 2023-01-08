using Telesignal.Common.Database.Repositories;
using Telesignal.Common.Database.Repositories.Interfaces;

namespace Telesignal.Common.Database.Config;

public static class DatabaseDependencyConfiguration
{
    public static void AddDependencies(IServiceCollection services) {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IMessageRepository, MessageRepository>();
        services.AddScoped<IProfileRepository, ProfileRepository>();
        services.AddScoped<IRoomRepository, RoomRepository>();
    }
}
