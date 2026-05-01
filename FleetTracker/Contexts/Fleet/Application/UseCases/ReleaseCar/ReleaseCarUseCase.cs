using FleetTracker.Contexts.Fleet.Application.UseCases.AssignCar;
using FleetTracker.Contexts.Fleet.Domain.Entities;
using FleetTracker.Contexts.Fleet.Domain.Repositories;

namespace FleetTracker.Contexts.Fleet.Application.UseCases.ReleaseCar
{
    public class ReleaseCarUseCase
    {
        private readonly ICarRepository _carRepository;

        public ReleaseCarUseCase(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public void Run(ReleaseCarDTO releaseCarDTO)
        {
            try
            {
                Car car = _carRepository.FindById(releaseCarDTO.CarId);
                if (car.Active == false)
                {
                    throw new Exception("Carro não está ativo");
                }

                car.Active = false;

                _carRepository.Update(car);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
