using Eg.rel.AuthService.Data;
using Eg.rel.AuthService.DTOs;
using Eg.rel.AuthService.Exceptions;
using Eg.rel.AuthService.Models;
using Eg.rel.AuthService.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Eg.rel.AuthService.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly UserContext _dbContext;
        private readonly ITokenService _tokenService;

        public AuthorizationService(UserContext dbContext, ITokenService tokenService)
        {
            _dbContext = dbContext;
            _tokenService = tokenService;
        }

        public async Task<UserDto> Login(LoginDto loginDto)
        {
            var user = await _dbContext.Users
                .SingleOrDefaultAsync(a => a.Email == loginDto.Email.ToLower());

            if (user == null)
                throw new UnauthorizedException("Invalid Username!");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                    throw new UnauthorizedException("Invalid Password!");
            }

            return new UserDto
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user)
            };
        }

        public async Task<UserDto> Register(RegisterDto registerDto)
        {
            using var hmac = new HMACSHA512();

            var user = new UserEntity
            {
                Email = registerDto.Email.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return new UserDto
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user)
            };
        }


        public async Task<bool> UserExists(string email)
        {
            return await _dbContext.Users.AnyAsync(x => x.Email == email.ToLower());
        }
    }
}
