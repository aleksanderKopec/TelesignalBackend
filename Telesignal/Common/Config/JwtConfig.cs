using System.Text;

namespace Telesignal.Common.Config;

public class JwtConfig
{
    public const int ExpirationHours = 5;
    
    readonly private IConfiguration _configuration;
    
    public JwtConfig(IConfiguration configuration) {
        _configuration = configuration;
    }

    public string JwtIssuer => _configuration.GetValue<string>(AppSettings.JwtIssuer);
    public string JwtAudience => _configuration.GetValue<string>(AppSettings.JwtAudience);
    public byte[] JwtKey => 
        Encoding.UTF8.GetBytes(_configuration.GetValue<string>(AppSettings.JwtKey));
}
