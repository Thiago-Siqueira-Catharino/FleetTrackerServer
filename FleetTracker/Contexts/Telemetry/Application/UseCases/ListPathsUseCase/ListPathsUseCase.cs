using FleetTracker.Contexts.Telemetry.Domain.Repositories;
using Path = FleetTracker.Contexts.Telemetry.Domain.Entities.Path;

namespace FleetTracker.Contexts.Telemetry.Application.UseCases.ListPathsUseCase;

public class ListPathsUseCase
{
    private readonly IPathRepository _repository;

    public ListPathsUseCase(IPathRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Path>> RunAsync()
    {
        return await _repository.GetAllAsync();
    }
}