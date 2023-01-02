using Eg.rel.AuthService.Models;

namespace Eg.rel.AuthService.Services.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(UserEntity user);
    }
}
