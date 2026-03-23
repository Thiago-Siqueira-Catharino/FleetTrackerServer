namespace FleetTracker.Domain.Entities;

public class Coordinate
{
    public double latitude { get; private set; }
    public double longitude { get; private set; }

    public Coordinate(double latitude, double longitude)
    {
        Dictionary<string, double> coordinates = new Dictionary<string, double>
        {
            {"latitude", latitude},
            {"longitude", longitude}
        };
        foreach (var paramater in coordinates)
        {
            if (String.IsNullOrEmpty(paramater.Value.ToString()))
                throw new ArgumentException($"{paramater.Key} must not be empty");
        }
    }
}