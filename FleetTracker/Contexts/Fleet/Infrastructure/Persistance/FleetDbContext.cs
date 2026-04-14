using Microsoft.EntityFrameworkCore;
using FleetTracker.Contexts.Fleet.Domain.Entities;

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
        
        base.OnModelCreating(modelBuilder);
    }
}