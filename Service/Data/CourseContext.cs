using Microsoft.EntityFrameworkCore;
using Service.Entities;

namespace Service.Data;

public class CourseContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public CourseContext(DbContextOptions<CourseContext> options)
      : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        SetUserBuilder(modelBuilder);
    }

    private void SetUserBuilder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .Property(e => e.Username)
            .HasMaxLength(250)
            .IsRequired();

        modelBuilder.Entity<User>()
            .HasIndex(e => e.Username)
            .IsUnique();

        modelBuilder.Entity<User>()
            .Property(e => e.Name)
            .HasMaxLength(255)
            .IsRequired();

        modelBuilder.Entity<User>()
            .Property(e => e.Password)
            .HasMaxLength(255)
            .IsRequired();

        modelBuilder.Entity<User>()
            .Property(e => e.Role)
            .HasMaxLength(255)
            .IsRequired();

        modelBuilder.Entity<User>()
            .HasData(new User
            {
                Active = true,
                Id = 1,
                Name = "Administrador",
                Username = "admin@admin.com",
                Password = "admin321",
                Role = Role.Administrador
            });

        modelBuilder.Entity<User>()
            .HasData(new User
            {
                Active = true,
                Id = 2,
                Name = "Cliente",
                Username = "client@client.com",
                Password = "client321",
                Role = Role.Cliente
            });
    }
}
