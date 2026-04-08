using FleetTracker.Contexts.Fleet.Domain.Entities;
using FleetTracker.Contexts.Fleet.Domain.Repositories;
using FleetTracker.Contexts.Fleet.Infrastructure.Persistance;

namespace FleetTracker.Contexts.Fleet.Infrastructure.Repositories;

public class CarRepository : ICarRepository
{
    public readonly FleetDbContext _database;
    public CarRepository(FleetDbContext database)
    {
        _database = database;
    }
    
    public Car FindById(Guid carId)
    {
        Car car =  _database.Cars.Find(carId);
        if (car == null)
            throw new KeyNotFoundException($"Car with id {carId} does not exist");
        
        return car;
    }

    public Car FindByPlate(string plate)
    {
        Car car =  _database.Cars.FirstOrDefault(c => c.Plate == plate);
        if (car == null)
            throw new KeyNotFoundException($"Car with plate {plate} does not exist");
        
        return car;
    }
}