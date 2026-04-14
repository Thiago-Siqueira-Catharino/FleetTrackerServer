using FleetTracker.Contexts.Fleet.Domain.Entities;
using FleetTracker.Contexts.Fleet.Domain.Repositories;
using FleetTracker.Contexts.Fleet.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace FleetTracker.Contexts.Fleet.Infrastructure.Repositories;

public class CarRepository : ICarRepository
{
    public readonly FleetDbContext _database;
    public CarRepository(FleetDbContext database)
    {
        _database = database;
    }
    
    public async Task<Car> FindById(Guid carId)
    {
        Car car =  await _database.Cars.FindAsync();
        if (car == null)
            throw new KeyNotFoundException($"Car with id {carId} does not exist");
        
        return car;
    }

    public async Task<Car> FindByPlate(string plate)
    {
        Car car = await _database.Cars.FirstOrDefaultAsync(c => c.Plate == plate);
        if (car == null)
            throw new KeyNotFoundException($"Car with plate {plate} does not exist");
        
        return car;
    }

    public async Task Create(Car car)
    { 
        await _database.Cars.AddAsync(car);
        await _database.SaveChangesAsync();
    }
}