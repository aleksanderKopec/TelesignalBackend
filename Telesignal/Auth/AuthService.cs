using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Telesignal.Auth.DTO;
using Telesignal.Auth.Interfaces;
using Telesignal.Common.Config;

namespace Telesignal.Auth;

public class AuthService : IAuthService
{
    private JwtConfig _jwtConfig;
    
    public AuthService(JwtConfig jwtConfig) {
        _jwtConfig = jwtConfig;
    }

    public async Task<IResult> Login(LoginDto loginDto) {
        if (loginDto.Username != "username" || loginDto.Password != "password") {
            return Results.Unauthorized();
        }

        return await Task.Run(() => {
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new[] {
                    new Claim("Id", Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, loginDto.Username),
                    new Claim(JwtRegisteredClaimNames.Email, loginDto.Username),
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
            return Results.Ok(stringToken);
        });
    }
}
