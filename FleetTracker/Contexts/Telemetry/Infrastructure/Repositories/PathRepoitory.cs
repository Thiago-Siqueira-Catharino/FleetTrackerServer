using FleetTracker.Contexts.Telemetry.Domain.Repositories;
using FleetTracker.Contexts.Telemetry.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Path = FleetTracker.Contexts.Telemetry.Domain.Entities.Path;

namespace FleetTracker.Contexts.Telemetry.Infrastructure.Repositories;

public class PathRepository : IPathRepository
{
    public readonly TelemetryDbContext _database;
    public PathRepository(TelemetryDbContext telemetryDbContext)
    {
        _database =  telemetryDbContext;
    }
    
    public async Task AddAsync(Domain.Entities.Path newPath)
    {
        await _database.Paths.AddAsync(newPath);
        await _database.SaveChangesAsync();
    }

    public async Task<Domain.Entities.Path?> FindByIdAsync(Guid pathId)
    {
        Domain.Entities.Path? path = await _database.Paths
            .FirstOrDefaultAsync(p => p.Id == pathId);
        return path;
    }

    public async Task UpdateAsync(Domain.Entities.Path pathToUpdate)
    {
        _database.Paths.Update(pathToUpdate);
        await _database.SaveChangesAsync();
    }

    public async Task<List<Domain.Entities.Path>> FindByCarIdAsync(Guid carId)
    {
        return await _database.Paths
            .Where(p => p.carId == carId)
            .OrderByDescending(p => p.createdAt)
            .ToListAsync();
    }
    
    public Task<List<Path>> GetAllAsync()
    {
        return _database.Paths
            .OrderByDescending(path => path.createdAt)
            .ToListAsync();
    }
}