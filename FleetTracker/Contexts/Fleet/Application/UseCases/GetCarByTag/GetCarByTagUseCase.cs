using FleetTracker.Contexts.Fleet.Domain.Entities;
using FleetTracker.Contexts.Fleet.Domain.Repositories;

namespace FleetTracker.Contexts.Fleet.Application.UseCases.GetCarByTag;

public class GetCarByTagUseCase
{
    private readonly ICarRepository _carRepository;

    public GetCarByTagUseCase(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<Car> RunAsync(string tag)
    {
        return await _carRepository.FindByTag(tag);
    }
}