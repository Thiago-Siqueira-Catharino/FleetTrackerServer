namespace FleetTracker.Contexts.Fleet.Domain.Repositories;

public interface ICarRepository
{
    public Car FindById(Guid id);
    public Car FindByPlate(string plate);
}