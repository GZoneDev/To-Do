using Microsoft.EntityFrameworkCore;
using TaskPlatform.Persistence.Repository.Configuration;
using TaskPlatform.Persistence.Repository.Entitys;

namespace TaskPlatform.Persistence.Repository;

public class TaskDbContext : DbContext
{
    public DbSet<CategoryEntity> Categorys { get; set; }
    public DbSet<TaskEntity> Tasks { get; set; }

    public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration<CategoryEntity>(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration<TaskEntity>(new TaskConfiguration());
    }
}
