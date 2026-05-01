using FleetTracker.Contexts.Telemetry.Application.UseCases.RegisterCarLocation;
using FleetTracker.Contexts.Telemetry.Domain.Entities;

namespace FleetTracker.Contexts.Telemetry.Domain.Repositories;

public interface ILocationRepository
{
    public Task AddAsync(LocationPoint request);
    public Task<IEnumerable<LocationPoint>> GetHistoryByCarAndDateAsync(Guid carId, DateTime startDate, DateTime endDate);
}