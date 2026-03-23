namespace FleetTracker.Domain.Entities;

public class LocationPoint :  EntityBase
{
    public DateTime timeStamp { get; private set; }
    public Coordinate coordinate  { get; private set; }
    public double fuelLevel { get; private set; }
}