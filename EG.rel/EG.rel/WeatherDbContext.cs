using Microsoft.EntityFrameworkCore;

namespace EG.rel
{
    public class WeatherDbContext:DbContext
    {
        public WeatherDbContext(DbContextOptions options) : base(options) { }
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}
