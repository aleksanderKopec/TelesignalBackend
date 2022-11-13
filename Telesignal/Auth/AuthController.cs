using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Telesignal.Auth.DTO;
using Telesignal.Auth.Interfaces;

namespace Telesignal.Auth;

[ApiController]
[Route("/auth")]
[AllowAnonymous]
public class AuthController : ControllerBase, IAuthController
{
    readonly private IAuthService _authService;

    public AuthController(IAuthService authService) {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<object>> Login(LoginDto loginDto) {
        return await _authService.Login(loginDto);
    }

    [HttpPost("register")]
    public async Task<ActionResult<object>> Register(RegisterDto registerDto) {
        return await _authService.Register(registerDto);
    }
}
