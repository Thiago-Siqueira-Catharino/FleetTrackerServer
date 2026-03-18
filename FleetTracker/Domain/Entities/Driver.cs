namespace FleetTracker.Domain.Entities;

public class Driver : EntityBase
{
    public string name { get; private set; }
    public string email { get; private set; }
    public string password { get; private set; }
    public string document { get; private set; }
    public string department { get; private set; }

    public Driver(string name, string email, string password,
        string document, string department)
    {
        Dictionary<string, string> parameters = new Dictionary<string, string>
        {
            {"name", name},
            {"email", email},
            {"password", password},
            {"document", document},
            {"department", department}
        };
        foreach (var parameter in parameters)
        {
            if (string.IsNullOrEmpty(parameter.Value))
                throw new ArgumentException(parameter.Key + " must not be null or empty");
        }
        
        this.name = name;
        this.email = email;
        this.password = password;
        this.document = document;
        this.department = department;
    }
}