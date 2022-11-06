using Microsoft.AspNetCore.Identity;
using Telesignal.Auth.DTO;
using Telesignal.Auth.Interfaces;
using Telesignal.Auth.Interfaces.Utils;
using Telesignal.Common.Config;
using Telesignal.Common.Database.EntityFramework.Model;

namespace Telesignal.Auth;

public class AuthService : IAuthService
{
    readonly private IAuthUserRepository _authUserRepository;
    readonly private IPasswordHasher<Email> _emailHasher;
    readonly private IJwtUtils _jwtUtils;
    readonly private IPasswordHasher<User> _passwordHasher;

    public AuthService(JwtConfig jwtConfig, IJwtUtils jwtUtils, IAuthUserRepository authUserRepository,
                       IPasswordHasher<User> passwordHasher, IPasswordHasher<Email> emailHasher) {
        _jwtUtils = jwtUtils;
        _authUserRepository = authUserRepository;
        _passwordHasher = passwordHasher;
        _emailHasher = emailHasher;
    }

    public async Task<IResult> Login(LoginDto loginDto) {
        var user = new User();
        if (loginDto.Username != "username" || loginDto.Password != "password") {
            return Results.Unauthorized();
        }
        var user = new
        return async _jwtUtils.GetJwtToken()
    }

    public async Task<IResult> Register(RegisterDto registerDto) {
    }
}
