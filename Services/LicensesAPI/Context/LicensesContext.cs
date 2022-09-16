namespace LicensesAPI.Context;

using Microsoft.EntityFrameworkCore;
using LicensesAPI.Models;

public class LicensesContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public LicensesContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("license");

        modelBuilder.Entity<License>()
            .HasOne(p => p.Type);
        modelBuilder.Entity<LicenseType>();
    }

    public DbSet<License> Licenses { get; set; }
    public DbSet<LicenseType> LicenseTypes { get; set; }
}
