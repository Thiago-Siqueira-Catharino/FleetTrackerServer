namespace FleetTracker.Contexts.Fleet.Domain;

public class Car
{
    public string TagUid { get; }
    public string Model { get; set; }
    public string Plate { get; set; }

    public Car(string tagUid, string model, string plate, float averageConsumption)
    {
        TagUid = tagUid;
        Model = model;  
        Plate = plate;
    }
}