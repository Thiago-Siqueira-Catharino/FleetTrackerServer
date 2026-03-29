namespace FleetTracker.Domain.ValueObjects;

public class Coordinate : ValueObject
{
    public double latitude { get; private set; }
    public double longitude { get; private set; }

    public Coordinate(double latitude, double longitude)
    {
        //REMOVIDO----------------------------------------------------------------
        /*
        
        Dictionary<string, double> coordinates = new Dictionary<string, double> //Não entendi o por que do Dictionary, mas se precisar adapto utilizando ele
        {
            {"latitude", latitude},
            {"longitude", longitude}
        };
        

        foreach (var paramater in coordinates) //double nunca será nulo, ele assume 0 quando não recebe um valor
        {
            if (String.IsNullOrEmpty(paramater.Value.ToString()))
                throw new ArgumentException($"{paramater.Key} must not be empty");
        }
        */
        //------------------------------------------------------------------------

        if (latitude < -90 || latitude > 90)
            throw new ArgumentException("A latitude deve situar-se entre -90 e 90 graus.", nameof(latitude));

        if (longitude < -180 || longitude > 180)
            throw new ArgumentException("A longitude deve situar-se entre -180 e 180 graus.", nameof(longitude));

        this.latitude = latitude;
        this.longitude = longitude;

    }

    protected override IEnumerable<object> GetEqualityComponents() //Diz à classe base ValueObject quais propriedades definem igualdade
    {
        yield return Latitude;
        yield return Longitude;
    }
}