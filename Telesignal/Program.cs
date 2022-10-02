using Serilog;
using Telesignal.Common.Config;
using Telesignal.Common.Extensions;

namespace Telesignal;

public class Program
{
    public static void Main(string[] args) {
        var builder = WebApplication.CreateBuilder(args);

        // Configure logging
        var configuration = new LoggerConfiguration()
                           .WriteTo.Console()
                           .WriteTo.File("logs/Telesignal.log", rollingInterval: RollingInterval.Day);
        configuration = builder.Environment.IsDevelopment()
                            ? configuration.MinimumLevel.Debug()
                            : configuration.MinimumLevel.Information();
        Log.Logger = configuration.CreateLogger();

        try {
            // Services configuration
            var dbConnectionString = builder.Configuration.GetConnectionString(AppSettings.DbConnectionString);

            var app = builder
                     .ConfigureDatabase(dbConnectionString)
                     .ConfigureServices()
                     .ConfigureIdentityServer()
                     .Build();

            app
               .ConfigurePipeline()
               .Run();
        }
        catch (Exception ex) when (
            ex.GetType().Name is not "StopTheHostException") // https://github.com/dotnet/runtime/issues/60600
        {
            Log.Fatal(ex, "Unhandled exception");
        }
        finally {
            Log.Information("Shut down complete");
            Log.CloseAndFlush();
        }
    }
}
