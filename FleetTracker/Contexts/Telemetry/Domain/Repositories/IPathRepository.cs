using FleetTracker.Contexts.Telemetry.Domain.Entities;

namespace FleetTracker.Contexts.Telemetry.Domain.Repositories;

public interface IPathRepository
{
    public Task AddAsync(Entities.Path pathToSave);
    public Task UpdateAsync(Entities.Path pathToUpdate);
    public Task<Entities.Path?> FindByIdAsync(Guid pathId);
    
}