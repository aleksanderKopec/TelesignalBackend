using Microsoft.EntityFrameworkCore;
using Telesignal.Common.Database.EntityFramework.Model;

namespace Telesignal.Common.Database.EntityFramework;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    public DbSet<Room> Rooms { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Email> Emails { get; set; }
    public DbSet<User> Users { get; set; }
}
