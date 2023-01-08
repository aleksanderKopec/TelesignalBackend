using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Telesignal.Auth.DTO;
using Telesignal.Auth.Interfaces;
using Telesignal.Auth.Interfaces.Utils;
using Telesignal.Auth.Model;
using Telesignal.Auth.Utils;
using Telesignal.Common.Database.Repositories.Interfaces;
using DatabaseModel = Telesignal.Common.Database.EntityFramework.Model;

namespace Telesignal.Auth;

public class AuthService : IAuthService
{
    readonly private IUserRepository _authUserRepository;
    readonly private IEmailHasher _emailHasher;
    readonly private IJwtUtils _jwtUtils;
    readonly private IPasswordHasher _passwordHasher;
    public AuthService(IJwtUtils jwtUtils, IUserRepository authUserRepository,
                       IPasswordHasher passwordHasher, IEmailHasher emailHasher) {
        _jwtUtils = jwtUtils;
        _authUserRepository = authUserRepository;
        _passwordHasher = passwordHasher;
        _emailHasher = emailHasher;
    }

    public async Task<ActionResult<object>> Login(LoginDto loginDto) {
        var databaseUser = await _authUserRepository.FindByUsername(loginDto.Username);
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
        var emailHash = _emailHasher.HashEmail(registerDto.Email);
        var encodedKey = Convert.FromBase64String(registerDto.PublicKey);
        try {
            await _authUserRepository.Create(new User(
                                                     registerDto.Username,
                                                     Email.Parse(registerDto.Email, emailHash.Hash),
                                                     passwordHash,
                                                     encodedKey)
                                                .ToModel());
        }
        catch (DbUpdateException e) {
            Log.Logger.Error("User with this name already exists. StackTrace: {Stacktrace}", e.StackTrace);
            return new UnprocessableEntityObjectResult(RegisterResultMessages.UserAlreadyExists);
        }
        return new OkObjectResult(RegisterResultMessages.Success);
    }
}
