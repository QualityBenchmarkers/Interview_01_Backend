using Interview.Database.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Interview.Database.Configuration
{
    public class CommandCenterContext : DbContext
    {
        public CommandCenterContext(DbContextOptions<CommandCenterContext> options) : base(options)
        {
        }


        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }

    }
}
