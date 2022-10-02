namespace Telesignal.Common.Config;

internal static class AppSettings
{
    internal const string DbConnectionString = "DatabaseConnectionString";
    internal const string JwtBearer = "Bearer";

    readonly internal static string AppUrl = Environment.GetEnvironmentVariable(EnvironmentVariables.API_URL)!;
}
