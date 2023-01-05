using EG.rel.ProfileService.Entities;
using Microsoft.EntityFrameworkCore;

namespace EG.rel.ProfileService.Data
{
    public class ProfileDbContext : DbContext
    {
        public ProfileDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<ProfileUser> Profiles { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
    }
}
