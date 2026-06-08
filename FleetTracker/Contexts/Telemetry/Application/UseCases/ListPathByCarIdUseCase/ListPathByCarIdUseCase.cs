using FleetTracker.Contexts.Telemetry.Domain.Repositories;
using Path = FleetTracker.Contexts.Telemetry.Domain.Entities.Path;

namespace FleetTracker.Contexts.Telemetry.Application.UseCases.ListPathByCarIdUseCase;

public class ListPathByCarIdUseCase
{
    private readonly IPathRepository _repository;

    public ListPathByCarIdUseCase(IPathRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Path>> RunAsync(Guid carId)
    {
        if (carId == Guid.Empty)
            throw new ArgumentNullException("Id vazio");
        
        return await _repository.FindByCarIdAsync(carId);
    }
}