namespace FleetTracker.Contexts.Fleet.Application.UseCases.RegisterCarLocation
{
    public class RegisterCarLocationDTO
    {
        public Guid CarId { get; set; }
        public Guid DriverId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
