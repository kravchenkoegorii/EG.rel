using Eg.rel.AuthService.Models;

namespace Eg.rel.AuthService.Services
{
    public interface ITokenService
    {
        string CreateToken(UserEntity user);
    }
}
