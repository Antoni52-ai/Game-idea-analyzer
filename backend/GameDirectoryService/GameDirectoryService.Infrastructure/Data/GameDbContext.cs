using Microsoft.EntityFrameworkCore;
using GameDirectoryService.Domain.Entities;

namespace GameDirectoryService.Infrastructure.Data;

public class GameDbContext : DbContext
{
    public GameDbContext(DbContextOptions<GameDbContext> options) : base(options) 
    { 
    }

    public DbSet<Game> Games { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
            entity.Property(e => e.Price).HasColumnType("decimal(10,2)");
            entity.Property(e => e.Genres).HasMaxLength(500);
            entity.Property(e => e.Tags).HasMaxLength(500);
        });
    }
}