using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using TaskPlatform.Persistence.Repository.Entitys;

namespace TaskPlatform.Persistence.Repository.Configuration;

public class TaskConfiguration : IEntityTypeConfiguration<TaskInfoEntity>
{
    public void Configure(EntityTypeBuilder<TaskInfoEntity> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .IsRequired();

        builder.HasIndex(t => t.Id)
            .IsUnique();

        builder.Property(t => t.CategoryId)
            .IsRequired();

        builder.Property(t => t.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(t => t.Description)
            .HasMaxLength(1000)
            .IsRequired();

        builder.HasOne(t => t.Category)
            .WithMany(c => c.Tasks)
            .HasForeignKey(t => t.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
