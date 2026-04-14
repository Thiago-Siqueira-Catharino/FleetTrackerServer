using FleetTracker.Contexts.Fleet.Domain.Entities;
using FleetTracker.Contexts.Fleet.Domain.Repositories;

namespace FleetTracker.Contexts.Fleet.UseCases.RegisterNewCar;

public class RegisterNewCarUseCase
{
    ICarRepository _carRepository;

    public RegisterNewCarUseCase(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<Car> Run(RegisterCarDTO car)
    {
        if (car == null)
            throw  new ArgumentException( "Informações inválidas");
        
        Car carToRegister = new Car(car.tagUid, car.model, car.plate);
        if (carToRegister == null)
            throw new ArgumentException("Algo deu errado");
        
        _carRepository.Create(carToRegister);
        return carToRegister;
    }
}