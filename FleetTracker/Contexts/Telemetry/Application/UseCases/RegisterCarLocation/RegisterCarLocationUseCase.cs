using FleetTracker.Contexts.Telemetry.Domain.Entities;
using FleetTracker.Contexts.Telemetry.Domain.ValueObjects;
using FleetTracker.Contexts.Telemetry.Domain.Repositories;

namespace FleetTracker.Contexts.Telemetry.Application.UseCases.RegisterCarLocation
{
    public class RegisterCarLocationUseCase
    {
        private readonly ILocationRepository _locationRepository; //Precisa criar ainda
        private readonly ICarRepository _carRepository;

        public RegisterCarLocationUseCase(ILocationRepository locationRepository, ICarRepository carRepository)
        {
            _locationRepository = locationRepository;
            _carRepository = carRepository;
        }

        public async Task ExecuteAsync(RegisterCarLocationDTO request)
        {
            var car = await _carRepository.FindById(request.CarId);
            if (car == null)
            {
                throw new Exception("Carro não encontrado.");
            }

            var coordinate = new Coordinate(request.Latitude, request.Longitude);

            var locationPoint = new LocationPoint(
                timeStamp:request.Timestamp,
                coordinate: coordinate,
                fuelLevel: request.FuelLevel
                //driverId: request.DriverId,
                //carId: request.CarId
            );

            await _locationRepository.AddAsync(locationPoint);
        }
    }
}
