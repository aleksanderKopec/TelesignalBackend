using Microsoft.EntityFrameworkCore;
using Telesignal.Common.Database.EntityFramework;
using Telesignal.Sample.Config;

namespace Telesignal.Common.Config;

internal static class DependencyConfiguration
{
    internal static void AddDependencies(IServiceCollection services) {
        SampleDependencyConfiguration.AddDependencies(services);
    }

    internal static void AddDatabaseDependencies(IServiceCollection services, string databaseConnectionString) {
//        services.AddScoped<DatabaseContext, DatabaseContext>();
        services.AddDbContext<DatabaseContext>(
            options => options.UseSqlServer(databaseConnectionString)
        );
    }
}
