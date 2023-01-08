using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Telesignal.Auth.DTO;
using Telesignal.Auth.Interfaces.Utils;
using Telesignal.Common.Config;
using Telesignal.Common.Database.EntityFramework.Model;

namespace Telesignal.Auth.Utils;

public class JwtUtils : IJwtUtils
{
    readonly private JwtConfig _jwtConfig;

    public JwtUtils(JwtConfig jwtConfig) {
        _jwtConfig = jwtConfig;
    }
    public async Task<TokenDto> GetJwtToken(User user) {
        return await Task.Run(() => {
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new[] {
                    new Claim("Id", Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                    new Claim(JwtRegisteredClaimNames.Email, user.Username)
                }),
                Expires = DateTime.UtcNow.AddHours(JwtConfig.ExpirationHours),
                Issuer = _jwtConfig.JwtIssuer,
                Audience = _jwtConfig.JwtAudience,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(_jwtConfig.JwtKey),
                    SecurityAlgorithms.HmacSha512Signature
                )
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var stringToken = tokenHandler.WriteToken(token);
            return new TokenDto(stringToken, user.Id);
        });
    }
}
