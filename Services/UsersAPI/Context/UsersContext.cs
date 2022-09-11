namespace UsersAPI.Context;

using Microsoft.EntityFrameworkCore;
using UsersAPI.Models;

public class UsersContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public UsersContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("user");

        modelBuilder.Entity<UserProperty>()
            .HasOne(p => p.User)
            .WithMany(b => b.UserProperties);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<UserProperty> UserProperties { get; set; }
}
