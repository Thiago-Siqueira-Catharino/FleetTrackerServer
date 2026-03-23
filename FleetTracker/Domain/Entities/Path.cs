namespace FleetTracker.Domain.Entities;

public class Path
{
    public Car car { get; private set;  }
    public List<LocationPoint> locationPoints { get; private set; }
}