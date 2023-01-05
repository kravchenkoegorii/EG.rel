using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EG.rel.ProfileService.Data;
using EG.rel.ProfileService.Entities;
using EG.rel.ProfileService.Services.Interfaces;
using EG.rel.ProfileService.DTOs;

namespace EG.rel.ProfileService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly IProfileService _profileService;
        public ProfilesController( IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfileUser>>> GetProfiles()
        {
            var profiles = await _profileService.GetProfiles();
            return Ok(profiles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProfileUser>> GetProfile(int id)
        {
            var profile = await _profileService.GetProfile(id);

            if (profile == null)
            {
                return NotFound();
            }

            return profile;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfile(int id, ProfileDto profileDto)
        {
            var sucsess = await _profileService.UpdateProfile(id, profileDto);
            if (!sucsess)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<ProfileUser>> UpdateProfile(InsertProfileDto profile)
        {
            await _profileService.InsertProfile(profile);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfile(int id)
        {
            var sucsess = await _profileService.DeleteProfile(id);
            if (!sucsess)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
