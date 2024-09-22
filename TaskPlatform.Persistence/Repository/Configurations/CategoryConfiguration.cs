using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskPlatform.Persistence.Repository.Entitys;

namespace TaskPlatform.Persistence.Repository.Configuration;

public class CategoryConfiguration : IEntityTypeConfiguration<CategoryEntity>
{
    public void Configure(EntityTypeBuilder<CategoryEntity> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .IsRequired();

        builder.Property(c => c.UserId)
            .IsRequired();

        builder.HasIndex(c => c.Id)
            .IsUnique();

        builder.Property(c => c.Name)
            .HasMaxLength(200)
            .IsRequired();
    }
}
