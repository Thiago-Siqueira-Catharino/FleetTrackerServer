using FleetTracker.Contexts.Telemetry.Application.UseCases.RegisterCarLocation;
using FleetTracker.Contexts.Telemetry.Domain.Repositories;

namespace FleetTracker.Contexts.Telemetry.Application.UseCases.CreatePathUseCase;

public class CreatePathUseCase
{
    private readonly IPathRepository _repository;
    
    public CreatePathUseCase(IPathRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> RunAsync(CreatePathDto request)
    {
        Domain.Entities.Path newPath = new Domain.Entities.Path(request.carId);
        await _repository.AddAsync(newPath);
        
        return newPath.Id;
    }
}