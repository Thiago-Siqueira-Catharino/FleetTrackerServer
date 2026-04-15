using FleetTracker.Contexts.Fleet.Domain.Entities;
using FleetTracker.Contexts.Fleet.Domain.Repositories;
using FleetTracker.Domain.Entities;

namespace FleetTracker.Contexts.Fleet.Application.UseCases.RegisterCarLocation
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

        public async Task ExecuteAsync(RecordCarLocationDTO request)
        {
            var car = await _carRepository.GetByIdAsync(request.CarId);
            if (car == null)
            {
                throw new Exception("Carro não encontrado.");
            }

            var coordinate = new Coordinate(request.Latitude, request.Longitude);

            var locationPoint = new LocationPoint(
                coordinate: coordinate,
                timestamp: request.Timestamp,
                driverId: request.DriverId,
                carId: request.CarId
            );

            await _locationRepository.AddAsync(locationPoint);
        }
    }
}
