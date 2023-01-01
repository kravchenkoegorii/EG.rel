﻿using Eg.rel.AuthService.DTOs;
using Eg.rel.AuthService.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Eg.rel.AuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AuthController
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthorizationService _authorizationService;

        public AuthController(IConfiguration configuration, IAuthorizationService authorizationService)
        {
            _configuration = configuration;
            authorizationService = _authorizationService;
        }

        /// <summary>
        /// Registers new user.
        /// </summary>
        /// <param name="registerDto">RegisterDto instance</param>
        [HttpPost("register")]
        [SwaggerOperation(
            Description = "Registers new user.",
            Summary = "Registers new user.")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto, CancellationToken token)
        {
            if (await _authorizationService.UserExists(registerDto.Email))
                return BadRequest("Username is taken!");

            return Ok(await _authorizationService.Register(registerDto));
        }

        /// <summary>
        /// Logs into user`s account.
        /// </summary>
        /// <param name="loginDto">LoginDto instance</param>
        [HttpPost("login")]
        [SwaggerOperation(
            Summary = "Logs into user`s account.",
            Description = "Logs into user`s account."
            )]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var result = await _authorizationService.Login(loginDto);
            return Ok(result);
        }
    }
}
