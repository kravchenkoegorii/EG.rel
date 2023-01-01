using Eg.rel.AuthService.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Eg.rel.AuthService.Services
{
    public interface IAuthorizationService
    {
        Task<UserDto> Register(RegisterDto registerDto);
        Task<UserDto> Login(LoginDto loginDto);
        Task<bool> UserExists(string email);
    }
}