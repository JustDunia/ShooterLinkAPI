using Microsoft.EntityFrameworkCore;
using ShooterLink.Data.Configurations;
using ShooterLink.Domain;
namespace ShooterLink.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public required DbSet<User> Users { get; init; }
    public required DbSet<Role> Roles { get; init; }
    public required DbSet<Setting> Settings { get; init; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        new RoleEntityConfiguration().Configure(builder.Entity<Role>());
        new SettingEntityConfiguration().Configure(builder.Entity<Setting>());
        new UserEntityConfiguration().Configure(builder.Entity<User>());
    }
}
