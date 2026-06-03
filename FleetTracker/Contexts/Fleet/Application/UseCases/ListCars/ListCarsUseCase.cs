using FleetTracker.Contexts.Fleet.Domain.Entities;
using FleetTracker.Contexts.Fleet.Domain.Repositories;

namespace FleetTracker.Contexts.Fleet.Application.UseCases.ListCars;

public class ListCarsUseCase
{
    private readonly ICarRepository _carRepository;

    public ListCarsUseCase(ICarRepository carRepository)
    {
        _carRepository =  carRepository;
    }

    public async Task<List<Car>> RunAsync()
    {
        return await _carRepository.GetAll();
    }
}