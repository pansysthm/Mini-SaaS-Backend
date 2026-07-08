using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using MiniSaaSBackend.Entities;

namespace MiniSaaSBackend.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (Debugger.IsAttached || Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
        {
            optionsBuilder.LogTo(Console.WriteLine).EnableSensitiveDataLogging();
        }
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<AppFile> Files { get; set; } = null!;
    public DbSet<AppTask> Tasks { get; set; } = null!;
    public DbSet<Notification> Notifications { get; set; } = null!;
    public DbSet<FeatureFlag> FeatureFlags { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // User Configurations
        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(u => u.Name).IsRequired().HasMaxLength(255);
            entity.HasIndex(u => u.Email).IsUnique();
            entity.Property(u => u.Email).IsRequired().HasMaxLength(256);
            entity.Property(u => u.PasswordHash).IsRequired();
            entity.Property(u => u.Role).IsRequired().HasMaxLength(50);
        });

        // AppFile Configurations
        modelBuilder.Entity<AppFile>(entity =>
        {
            entity.HasOne(f => f.User)
                  .WithMany(u => u.Files)
                  .HasForeignKey(f => f.UserId)
                  .OnDelete(DeleteBehavior.Cascade);
                  
            entity.Property(f => f.FileName).IsRequired().HasMaxLength(255);
            entity.Property(f => f.FilePath).IsRequired();
            entity.Property(f => f.ContentType).HasMaxLength(50);
        });

        // AppTask Configurations
        modelBuilder.Entity<AppTask>(entity =>
        {
            entity.HasOne(t => t.User)
                  .WithMany(u => u.Tasks)
                  .HasForeignKey(t => t.UserId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.Property(t => t.Name).IsRequired().HasMaxLength(255);
            entity.Property(t => t.Status).IsRequired().HasMaxLength(50);
        });

        // Notification Configurations
        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasOne(n => n.User)
                  .WithMany(u => u.Notifications)
                  .HasForeignKey(n => n.UserId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.Property(n => n.Message).IsRequired();
        });

        // FeatureFlag Configurations
        modelBuilder.Entity<FeatureFlag>(entity =>
        {
            entity.HasIndex(f => f.Key).IsUnique();
            entity.Property(f => f.Key).IsRequired().HasMaxLength(100);
            entity.Property(f => f.Description).HasMaxLength(255);
        });
    }
}
