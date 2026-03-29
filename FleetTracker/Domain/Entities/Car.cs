using FleetTracker.Domain.ValueObjects;

namespace FleetTracker.Domain.Entities;

public class Car : EntityBase
{
    public string TagUid { get; } //LEMBRETE: confirmar tipo de tag para criar um ValueObject próprio
    public string Model { get; set; }
    public LicensePlate Plate { get; private set; }
    public List<Path> Paths { get; set; } = new List<Path>();

    public Car(string tagUid, string model, LicensePlate plate, float averageConsumption)
    {
        TagUid = tagUid;
        Model = model;  
        Plate = plate;
    }
}