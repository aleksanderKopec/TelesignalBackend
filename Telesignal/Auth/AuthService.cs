using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Telesignal.Auth.DTO;
using Telesignal.Auth.Interfaces;
using Telesignal.Auth.Interfaces.Utils;
using Telesignal.Auth.Model;
using Telesignal.Auth.Utils;

namespace Telesignal.Auth;

public class AuthService : IAuthService
{
    readonly private IAuthUserRepository _authUserRepository;
    readonly private IEmailHasher _emailHasher;
    readonly private IJwtUtils _jwtUtils;
    readonly private IPasswordHasher _passwordHasher;
    public AuthService(IJwtUtils jwtUtils, IAuthUserRepository authUserRepository,
                       IPasswordHasher passwordHasher, IEmailHasher emailHasher) {
        _jwtUtils = jwtUtils;
        _authUserRepository = authUserRepository;
        _passwordHasher = passwordHasher;
        _emailHasher = emailHasher;
    }

    public async Task<ActionResult<object>> Login(LoginDto loginDto) {
        var databaseUser = await _authUserRepository.FindUserByName(loginDto.Username);
        if (databaseUser is null) {
            return new NotFoundObjectResult(LoginResultMessages.UserDoesNotExist);
        }

        return !_passwordHasher.CompareHash(loginDto.Password, databaseUser.PasswordHash)
                   ? new UnauthorizedObjectResult(LoginResultMessages.InvalidPassword)
                   : new OkObjectResult(await _jwtUtils.GetJwtToken(databaseUser));
    }

    public async Task<ActionResult<object>> Register(RegisterDto registerDto) {
        if (registerDto.Password != registerDto.RepeatPassword) {
            return new BadRequestObjectResult(RegisterResultMessages.PasswordMismatch);
        }
        var passwordHash = _passwordHasher.HashPassword(registerDto.Password);
        var hashedEmail = _emailHasher.HashEmail(registerDto.Email);
        try {
            await _authUserRepository.AddUser(new User(registerDto.Username, hashedEmail, passwordHash));
        }
        catch (DbUpdateException e) {
            Log.Logger.Error("User with this database already exists. StackTrace: {Stacktrace}", e.StackTrace);
            return new UnprocessableEntityObjectResult(RegisterResultMessages.UserAlreadyExists);
        }
        return new OkObjectResult(RegisterResultMessages.Success);
    }
}
