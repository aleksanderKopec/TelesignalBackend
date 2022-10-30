using Telesignal.Auth.DTO;
using Telesignal.Auth.Interfaces;
using Telesignal.Auth.Interfaces.Utils;
using Telesignal.Common.Config;
using Telesignal.Common.Database.EntityFramework.Model;

namespace Telesignal.Auth;

public class AuthService : IAuthService
{
    readonly private IAuthUserRepository _authUserRepository;
    readonly private IJwtUtils _jwtUtils;

    public AuthService(JwtConfig jwtConfig, IJwtUtils jwtUtils, IAuthUserRepository authUserRepository) {
        _jwtUtils = jwtUtils;
        _authUserRepository = authUserRepository;
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
