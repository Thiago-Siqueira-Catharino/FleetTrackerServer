namespace FleetTracker.Contexts.Fleet.Application.UseCases.GetCarLocationHistory
{
    public class GetCarLocationHistoryDTO
    {
        public Guid CarId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
