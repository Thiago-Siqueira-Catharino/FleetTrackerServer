using FleetTracker.Contexts.Fleet.Domain.ValueObjects;

namespace FleetTracker.Contexts.Fleet.Domain.Entities;

public class Car
{
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime RemovedAt { get; private set; }
    public bool Active { get; private set; }
    public string TagUid { get; private set; }
    public string Model { get; set; }
    public LicensePlate Plate { get; private set; }

    public Car()
    { }
    
    public Car(string model, string plate)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        Model = model;  
        Plate = new LicensePlate(plate);;
        Active = true;
    }

    public void Deactivate()
    {
        Active = false;
    }

    public void Remove()
    {
        Active = false;
        RemovedAt = DateTime.Now;
    }

    public void SetTag(string tagUid)
    {
        TagUid = tagUid;
        
    }
}