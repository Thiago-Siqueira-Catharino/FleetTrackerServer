using FleetTracker.Contexts.Auth.Domain.Repositories;
using FleetTracker.Contexts.Fleet.Domain.Entities;
using FleetTracker.Contexts.Fleet.Domain.Repositories;
using FleetTracker.Contexts.Fleet.Infrastructure.Repositories;

namespace FleetTracker.Contexts.Fleet.Application.UseCases.AssignCar
{
    public class AssignCarUseCase
    {
        private readonly IDriverRepository _driverRepository; //criar interface
        private readonly ICarRepository _carRepository;

        public AssignCarUseCase(IDriverRepository driverRepository, ICarRepository carRepository)
        {
            _carRepository = carRepository;
            _driverRepository = driverRepository;
        }

        public void Run(AssignCarDTO assignCarDTO)
        {
            try
            {
                Driver driver = _driverRepository.GetDriverId(assignCarDTO.DriverId); //método não existe
                if (driver == null)
                {
                    throw new Exception("Motorista inexistente");
                }

                Car car = _carRepository.FindById(assignCarDTO.CarId);
                if (car == null)
                {
                    throw new Exception("Veículo inexistente");
                }

                car.Use(assignCarDTO.CarId, assignCarDTO.DriverId); //criar classe para trajeto?

                _carRepository.Update(car);
                _driverRepository.Update(driver);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            } 
        }
    }
}
