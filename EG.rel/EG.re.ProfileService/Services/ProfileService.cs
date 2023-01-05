using EG.rel.ProfileService.Data;
using EG.rel.ProfileService.DTOs;
using EG.rel.ProfileService.Entities;
using EG.rel.ProfileService.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EG.rel.ProfileService.Services
{
    public class ProfileService : IProfileService
    {
        private readonly ProfileDbContext _context;
        private readonly AutoMapper.IMapper _mapper;
        public ProfileService(ProfileDbContext context, AutoMapper.IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProfileUser>> GetProfiles()
        {
            return await _context.Profiles.ToListAsync();
        }

        public async Task<ProfileUser> GetProfile(int id)
        {
            var profile = await _context.Profiles.FindAsync(id);

            if (profile == null)
            {
                return null;
            }

            return profile;
        }

        public async Task<bool> UpdateProfile(int id, ProfileDto profileDto)
        {
            if (id != profileDto.Id)
                return false;
            var profile = await _context.Profiles.FindAsync(id);
            if (profile is not null)
                _mapper.Map(profileDto, profile);
            _context.Entry(profile).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> InsertProfile(InsertProfileDto profileDto)
        {
            var profile = _mapper.Map<ProfileUser>(profileDto);
            _context.Profiles.Add(profile);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteProfile(int id)
        {
            var profile = await _context.Profiles.FindAsync(id);
            if (profile == null)
            {
                return false;
            }

            _context.Profiles.Remove(profile);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
