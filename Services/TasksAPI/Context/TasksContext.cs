namespace TasksAPI.Context;

using Microsoft.EntityFrameworkCore;
using TasksAPI.Models;

public class TasksContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public TasksContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("task");

        modelBuilder.Entity<Task>()
            .HasOne(p => p.State);
    }

    public DbSet<Task> Tasks { get; set; }
    public DbSet<TaskState> TaskStates { get; set; }
}
