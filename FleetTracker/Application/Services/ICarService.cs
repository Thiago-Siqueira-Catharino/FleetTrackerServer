using FleetTracker.Domain.Entities;
using FleetTracker.Domain.DTOs.Requests;

namespace FleetTracker.Application.Services;
public interface ICarService
{
    Task<Car> RegisterNewCar(CreateCarDTO request);
    Task<Car> GetCarById(Guid id);
}