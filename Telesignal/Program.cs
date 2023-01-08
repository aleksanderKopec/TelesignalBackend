using Serilog;
using Telesignal.Common.Config;
using Telesignal.Common.Extensions;

namespace Telesignal;

public class Program
{
    private const string SIGNALR_PATH = "/chatHub";
    private const string LOG_PATH = "logs/Telesignal.log";

    public static void Main(string[] args) {
        var builder = WebApplication.CreateBuilder(args);

        // Configure logging
        var configuration = new LoggerConfiguration()
                           .WriteTo.Console()
                           .WriteTo.File(LOG_PATH, rollingInterval: RollingInterval.Day);
        configuration = builder.Environment.IsDevelopment()
                            ? configuration.MinimumLevel.Debug()
                            : configuration.MinimumLevel.Information();
        Log.Logger = configuration.CreateLogger();

        var dbConnectionString = builder.Configuration.GetConnectionString(AppSettings.DbConnectionString);


        var app = builder
                 .ConfigureDatabase(dbConnectionString)
                 .ConfigureAuthentication()
                 .ConfigureAuthorization()
                 .ConfigureServices()
                 .Build();
        app
           .ConfigurePipeline()
           .ConfigureSinglaR(SIGNALR_PATH)
           .Run();
    }
}
