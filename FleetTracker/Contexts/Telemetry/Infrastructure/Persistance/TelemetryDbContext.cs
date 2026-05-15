using FleetTracker.Contexts.Telemetry.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Path = System.IO.Path;

namespace FleetTracker.Contexts.Telemetry.Infrastructure.Persistance;

public class TelemetryDbContext  : DbContext
{
    public DbSet<LocationPoint> LocationPoints { get; set; }
    public DbSet<Domain.Entities.Path> Paths { get; set; }

    public TelemetryDbContext(DbContextOptions<TelemetryDbContext> options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LocationPoint>()
            .HasKey(point => point.Id);

        modelBuilder.Entity<LocationPoint>()
            .HasOne<Domain.Entities.Path>()
            .WithMany()
            .HasForeignKey(point => point.pathId);
        
        modelBuilder.Entity<Domain.Entities.Path>()
            .HasKey(path => path.Id);
    }
}