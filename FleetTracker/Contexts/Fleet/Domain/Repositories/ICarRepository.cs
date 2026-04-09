using FleetTracker.Contexts.Fleet.Domain.Entities;

namespace FleetTracker.Contexts.Fleet.Domain.Repositories;

public interface ICarRepository
{
    public Task<Car> FindById(Guid id);
    public Task<Car> FindByPlate(string plate);
    public Task Create(Car car);
}