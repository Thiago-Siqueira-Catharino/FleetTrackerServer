using FleetTracker.Contexts.Telemetry.Domain.Entities;
using FleetTracker.Contexts.Telemetry.Domain.ValueObjects;
using FleetTracker.Contexts.Telemetry.Domain.Repositories;

namespace FleetTracker.Contexts.Telemetry.Application.UseCases.RegisterCarLocation
{
    public class RegisterCarLocationUseCase
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IPathRepository _pathRepository;
        //private readonly ICarRepository _carRepository;
        
        public RegisterCarLocationUseCase(
            ILocationRepository locationRepository, 
            IPathRepository pathRepository
            )
        {
            _locationRepository = locationRepository;
            _pathRepository = pathRepository;
            //_carRepository = carRepository;
        }

        public async Task RunAsync(RegisterCarLocationDTO request)
        {
            var newCoordinate = new Coordinate(request.Latitude, request.Longitude);
            Console.WriteLine("New coordinate: " + newCoordinate.latitude + " " + newCoordinate.longitude);
            
            var locationPoint = new LocationPoint(
                timeStamp: request.Timestamp,
                coordinate: newCoordinate,
                fuelLevel: request.FuelLevel,
                speed: request.Speed
                //driverId: request.DriverId,
                //carId: request.CarId
            );
            Console.WriteLine($"New location point: time-{locationPoint.timeStamp} fuel-level-{locationPoint.fuelLevel}");

            Domain.Entities.Path path = await _pathRepository.FindByIdAsync(request.PathId);

            if (path == null)
                throw new ArgumentException("Esse caminho ainda não existe");
            
            locationPoint.SetPath(path);
            path.AddLocationPoint(locationPoint);
            
            await _locationRepository.AddAsync(locationPoint);
            await _pathRepository.UpdateAsync(path);
        }
    }
}
