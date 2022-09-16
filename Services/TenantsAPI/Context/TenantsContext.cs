namespace TenantsAPI.Context;

using Microsoft.EntityFrameworkCore;
using TenantsAPI.Models;

public class TenantsContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public TenantsContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("tenant");

        modelBuilder.Entity<Tenant>()
            .HasMany(p => p.Settings);
        modelBuilder.Entity<TenantSetting>();
        modelBuilder.Entity<TenantUser>();
    }

    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantSetting> TenantSettings { get; set; }
    public DbSet<TenantUser> TenantUsers { get; set; }
}
