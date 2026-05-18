using Microsoft.EntityFrameworkCore;
using FleetTracker.Contexts.Fleet.Domain.Entities;
using FleetTracker.Contexts.Fleet.Domain.ValueObjects;

namespace FleetTracker.Contexts.Fleet.Infrastructure.Persistance;

public class FleetDbContext : DbContext
{
    public DbSet<Car> Cars { get; set; }

    public FleetDbContext(DbContextOptions<FleetDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>()
            .HasKey(car => car.Id);

        modelBuilder.Entity<Car>()
            .HasAlternateKey(car => car.Plate);

        modelBuilder.Entity<Car>()
            .Property(car => car.Plate)
            .HasConversion(p => p.value, str => new LicensePlate(str));
        
        base.OnModelCreating(modelBuilder);
    }
}