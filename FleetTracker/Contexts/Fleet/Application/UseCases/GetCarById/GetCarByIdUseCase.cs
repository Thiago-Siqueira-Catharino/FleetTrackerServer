using FleetTracker.Contexts.Fleet.Domain.Entities;
using FleetTracker.Contexts.Fleet.Domain.Repositories;

namespace FleetTracker.Contexts.Fleet.Application.UseCases.GetCarById;

public class GetCarByIdUseCase
{
    ICarRepository _carRepository;

    public GetCarByIdUseCase(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<Car> Run(GetCarByIdDTO id)
    {
        return await _carRepository.FindById(id.value);
    }
}