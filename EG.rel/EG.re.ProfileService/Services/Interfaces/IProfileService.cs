using EG.rel.ProfileService.DTOs;
using EG.rel.ProfileService.Entities;

namespace EG.rel.ProfileService.Services.Interfaces
{
    public interface IProfileService
    {
        public Task<IEnumerable<ProfileUser>> GetProfiles();


        public Task<ProfileUser> GetProfile(int id);


        public Task<bool> UpdateProfile(int id, ProfileDto profileDto);


        public Task<bool> InsertProfile(InsertProfileDto profileDto);

        public Task<bool> DeleteProfile(int id);
    }
}
