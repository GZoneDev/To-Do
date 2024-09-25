using Microsoft.EntityFrameworkCore;
using TaskPlatform.Persistence.Repository.Configuration;
using TaskPlatform.Persistence.Repository.Entitys;

namespace TaskPlatform.Persistence.Repository;

public class TaskDbContext : DbContext
{
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<TaskInfoEntity> Tasks { get; set; }

    public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration<CategoryEntity>(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration<TaskInfoEntity>(new TaskConfiguration());

        modelBuilder.Entity<TaskInfoEntity>()
            .HasOne(t => t.Category)
            .WithMany(c => c.Tasks)
            .HasForeignKey(t => t.CategoryId);
    }
}
