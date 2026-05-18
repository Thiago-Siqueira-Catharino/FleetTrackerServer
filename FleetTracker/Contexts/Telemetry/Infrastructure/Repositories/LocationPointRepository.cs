using FleetTracker.Contexts.Telemetry.Domain.Entities;
using FleetTracker.Contexts.Telemetry.Domain.Repositories;
using FleetTracker.Contexts.Telemetry.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace FleetTracker.Contexts.Telemetry.Infrastructure.Repositories;

public class LocationPointRepository : ILocationRepository
{
    public readonly TelemetryDbContext _database;

    public LocationPointRepository(TelemetryDbContext telemetryDbContext)
    {
        _database =  telemetryDbContext;
    }

    public async Task AddAsync(LocationPoint locationPoint)
    {
        await _database.AddAsync(locationPoint);
        await _database.SaveChangesAsync();
    }

    public async Task<IEnumerable<LocationPoint>> GetByPathIdAsync(Guid toFind)
    {
        return await _database.LocationPoints
            .Where(point => point.pathId == toFind)
            .ToListAsync();
    }
}