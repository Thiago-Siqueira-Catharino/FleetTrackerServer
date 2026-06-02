using FleetTracker.Contexts.Fleet.Domain.Repositories;
using FleetTracker.Contexts.Fleet.Domain.Entities;
using FleetTracker.Contexts.Telemetry.Domain.Entities;
using FleetTracker.Contexts.Telemetry.Domain.Repositories;
using Path = FleetTracker.Contexts.Telemetry.Domain.Entities.Path;

namespace FleetTracker.Contexts.Fleet.Application.UseCases.GetCarLocationHistory
{
    public class GetCarLocationHistoryUseCase
    {
        private readonly IPathRepository _pathRepository; //Criar ainda

        public GetCarLocationHistoryUseCase(IPathRepository pathRepository)
        {
            _pathRepository = pathRepository;
        }

        public async Task<IEnumerable<Path>> ExecuteAsync(GetCarLocationHistoryDTO request)
        {
            var history = await _pathRepository.FindByCarIdAsync(
                request.CarId
            );

            return history;
        }
    }
}
