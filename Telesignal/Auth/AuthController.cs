using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Telesignal.Auth.DTO;
using Telesignal.Auth.Interfaces;
using Telesignal.Common.Database.EntityFramework.Model;
using Telesignal.Sample.Interfaces;

namespace Telesignal.Auth;

[ApiController]
[Route("/auth")]
public class AuthController : ControllerBase, IAuthController
{
    readonly private IAuthService _authService;

    public AuthController(IAuthService authService) {
        _authService = authService;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IResult> Login(LoginDto loginDto) {
        return await _authService.Login(loginDto);
    }
    
}
