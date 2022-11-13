using Microsoft.AspNetCore.Mvc;
using Telesignal.Auth.DTO;

namespace Telesignal.Auth.Interfaces;

public interface IAuthService
{
    public Task<ActionResult<object>> Login(LoginDto loginDto);

    public Task<ActionResult<object>> Register(RegisterDto registerDto);
}
