using Telesignal.Chat;
using Telesignal.Chat.Interfaces;

namespace Telesignal.Common.Config;

public static class ChatDependencyConfiguration
{
    public static void AddDependencies(IServiceCollection services) {
        services.AddScoped<IChatService, ChatService>();
    }
}
