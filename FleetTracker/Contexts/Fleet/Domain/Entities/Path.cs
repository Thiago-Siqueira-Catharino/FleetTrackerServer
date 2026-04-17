using FleetTracker.Domain.Entities;

namespace FleetTracker.Contexts.Fleet.Domain.Entities;

public class Path : EntityBase
{
    public Guid carId { get; private set;  }
    private List<LocationPoint> locationPoints { get; set; } = new List<LocationPoint>();

    public Path(Guid carId)
    {
        this.carId = carId;
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