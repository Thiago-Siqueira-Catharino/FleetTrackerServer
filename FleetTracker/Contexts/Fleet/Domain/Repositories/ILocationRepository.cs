using FleetTracker.Contexts.Fleet.Application.UseCases.RegisterCarLocation;
using FleetTracker.Contexts.Fleet.Domain.Entities;

namespace FleetTracker.Contexts.Fleet.Domain.Repositories;

public interface ILocationRepository
{
    public Task AddAsync(LocationPoint request);
    public Task<IEnumerable<LocationPoint>> GetHistoryByCarAndDateAsync(Guid carId, DateTime startDate, DateTime endDate);
}