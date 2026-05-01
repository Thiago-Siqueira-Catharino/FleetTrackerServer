using FleetTracker.Contexts.Fleet.Domain.Repositories;
using FleetTracker.Contexts.Fleet.Domain.Entities;

namespace FleetTracker.Contexts.Fleet.Application.UseCases.GetCarLocationHistory
{
    public class GetCarLocationHistoryUseCase
    {
        private readonly ILocationRepository _locationRepository; //Criar ainda

        public GetCarLocationHistoryUseCase(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<IEnumerable<LocationPoint>> ExecuteAsync(GetCarLocationHistoryDTO request)
        {
            var history = await _locationRepository.GetHistoryByCarAndDateAsync(
                request.CarId,
                request.StartDate,
                request.EndDate
            );

            return history;
        }
    }
}
