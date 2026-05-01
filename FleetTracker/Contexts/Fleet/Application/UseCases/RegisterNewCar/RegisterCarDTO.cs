namespace FleetTracker.Contexts.Fleet.UseCases.RegisterNewCar;

public class RegisterCarDTO
{
    public string tagUid { get; set; }
    public string model { get; set; }
    public string plate { get; set; }

    public RegisterCarDTO(string tagUid, string model, string plate)
    {
        //Verification of every single parameter
        Dictionary<String, String> parameters = new Dictionary<String, String>
        {
            { "taguid", tagUid },
            { "model", model },
            { "plate", plate }
        };
        foreach (var parameter in parameters)
        {
            if (String.IsNullOrEmpty(parameter.Value))
                throw  new ArgumentException($"Parameter {parameter.Key} must not be null or empty");
        }
        
        this.tagUid = tagUid;
        this.model = model;
        this.plate = plate;
    }
}