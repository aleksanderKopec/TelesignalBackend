namespace Telesignal.Common.Config;

internal static class AppSettings
{
    internal const string DbConnectionString = "DatabaseConnectionString";
    internal const string JwtIssuer = "Jwt:Issuer";
    internal const string JwtAudience = "Jwt:Audience";
    internal const string JwtKey = "Jwt:Key";
    
    readonly internal static string AppUrl = Environment.GetEnvironmentVariable(EnvironmentVariables.API_URL)!;
}
