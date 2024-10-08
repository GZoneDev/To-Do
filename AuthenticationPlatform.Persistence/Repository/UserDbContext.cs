﻿using Microsoft.EntityFrameworkCore;
using AuthenticationPlatform.Persistence.Repository.Configuration;
using AuthenticationPlatform.Persistence.Repository.Entitys;

namespace AuthenticationPlatform.Persistence.Repository;

public class UserDbContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }

    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration<UserEntity>(new UserConfiguration());
    }
}
