using Telesignal.Auth.DTO;
using Telesignal.Common.Database.EntityFramework.Model;

namespace Telesignal.Auth.Interfaces.Utils;

public interface IJwtUtils
{
    Task<TokenDto> GetJwtToken(User user);
}
