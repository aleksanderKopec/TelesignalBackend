using Microsoft.EntityFrameworkCore;

using Telesignal.Common.Database.EntityFramework.Model;

namespace Telesignal.Common.Database.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DatabaseContext(IConfiguration configuration) {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            options.UseSqlServer(Configuration.GetConnectionString("TelesignalTest"));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Email> Emails { get; set; }

    }
}
