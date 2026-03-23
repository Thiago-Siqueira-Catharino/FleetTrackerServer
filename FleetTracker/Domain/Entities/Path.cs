namespace FleetTracker.Domain.Entities;

public class Path
{
    public Car car { get; private set;  }
    private List<LocationPoint> locationPoints { get; set; } = new List<LocationPoint>();

    public Path(Car car)
    {
        this.car = car;
    }

    public void AddLocationPoint(LocationPoint locationPoint)
    {
        if (locationPoint is null)
        {
            throw new ArgumentException("Invalid location point");
        }

        if(locationPoints.Count > 0 && locationPoint.timeStamp <= locationPoints.Last().timeStamp)
            throw new ArgumentException("Invalid timestamp, time only moves foward");
        
        locationPoints.Add(locationPoint);
    }
}