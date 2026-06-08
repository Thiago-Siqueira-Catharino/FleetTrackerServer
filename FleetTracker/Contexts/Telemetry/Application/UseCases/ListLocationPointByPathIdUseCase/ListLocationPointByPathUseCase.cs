using FleetTracker.Contexts.Telemetry.Domain.Entities;
using FleetTracker.Contexts.Telemetry.Domain.Repositories;

namespace FleetTracker.Contexts.Telemetry.Application.UseCases.ListLocationPointByPathIdUseCase;

public class ListLocationPointByPathUseCase
{
    private readonly ILocationRepository _locationRepository;

    public ListLocationPointByPathUseCase(ILocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }

    public async Task<List<LocationPoint>> RunAsync(Guid pathId)
    {
        return await _locationRepository.GetByPathIdAsync(pathId);
    }
}