using Telesignal.Auth.DTO;

namespace Telesignal.Auth.Interfaces;

public interface IAuthService
{
    public Task<IResult> Login(LoginDto loginDto);
}
