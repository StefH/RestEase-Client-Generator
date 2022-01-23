namespace RestEaseClientGenerator.Models.Internal;

public class RestEaseInterfaceMethod
{
    public string ReturnType { get; set; } = null!;

    public string Name { get; set; } = null!;

    // public string ParametersAsString { get; set; }

    public ICollection<RestEaseParameter> Parameters { get; set; }
}