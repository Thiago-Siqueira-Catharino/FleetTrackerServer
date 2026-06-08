using FleetTracker.Contexts.Fleet.Domain.Entities;
using FleetTracker.Contexts.Telemetry.Application.UseCases.RegisterCarLocation;
using FleetTracker.Contexts.Telemetry.Domain.Repositories;
using ICarRepository = FleetTracker.Contexts.Fleet.Domain.Repositories.ICarRepository;

namespace FleetTracker.Contexts.Telemetry.Application.UseCases.CreatePathUseCase;

public class CreatePathUseCase
{
    private readonly IPathRepository _pathRepository;
    private readonly ICarRepository _carRepository;
    
    public CreatePathUseCase(IPathRepository pathRepository, ICarRepository carRepository)
    {
        _pathRepository = pathRepository;
        _carRepository = carRepository;
    }

    public async Task<Guid> RunAsync(CreatePathDto request)
    {
        Car car = await _carRepository.FindByTag(request.tagId);
        Domain.Entities.Path newPath = new Domain.Entities.Path(car.Id);
        await _pathRepository.AddAsync(newPath);
        
        return newPath.Id;
    }
}