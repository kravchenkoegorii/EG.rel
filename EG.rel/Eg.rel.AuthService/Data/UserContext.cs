using Eg.rel.AuthService.Models;
using Microsoft.EntityFrameworkCore;

namespace Eg.rel.AuthService.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<LoginEntity>? LoginModels { get; set; }
    }
}   