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

        var dbConnectionString = builder.Configuration.GetConnectionString(AppSettings.DbConnectionString);

        var app = builder
                 .ConfigureDatabase(dbConnectionString)
                 .ConfigureServices()
                 .Build();

        app
           .ConfigurePipeline()
           .Run();
    }
}
