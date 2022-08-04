namespace RestEaseClientGenerator.Models.Internal;

internal class RestEaseInterfaceMethod
{
    public string ReturnType { get; set; } = null!;

    public string Name { get; set; } = null!;

    public ICollection<RestEaseParameter> Parameters { get; set; }
}