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

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>()
                    .HasMany(user => user.AdminOf)
                    .WithMany(room => room.Admins);
        modelBuilder.Entity<User>()
                    .HasMany(user => user.MemberOf)
                    .WithMany(room => room.Members);
    }
}
