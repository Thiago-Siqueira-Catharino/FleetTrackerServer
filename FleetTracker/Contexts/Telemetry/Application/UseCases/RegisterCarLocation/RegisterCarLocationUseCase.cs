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
            ICarRepository carRepository,
            IPathRepository pathRepository
            )
        {
            _locationRepository = locationRepository;
            _pathRepository = pathRepository;
            //_carRepository = carRepository;
        }

        public async Task RunAsync(RegisterCarLocationDTO request)
        {
            var coordinate = new Coordinate(request.Latitude, request.Longitude);

            var locationPoint = new LocationPoint(
                timeStamp: request.Timestamp,
                coordinate: coordinate,
                fuelLevel: request.FuelLevel
                //driverId: request.DriverId,
                //carId: request.CarId
            );

            Domain.Entities.Path path = await _pathRepository.FindByIdAsync(request.PathId);

            if (path == null)
                throw new ArgumentException("Esse caminho ainda não existe");
            
            locationPoint.SetPath(path, path.Id);
            path.AddLocationPoint(locationPoint);
            
            await _locationRepository.AddAsync(locationPoint);
            await _pathRepository.UpdateAsync(path);
        }
    }
}
