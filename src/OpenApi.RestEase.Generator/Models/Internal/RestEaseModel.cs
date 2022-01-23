namespace OpenApi.RestEase.Generator.Models.Internal;

public class RestEaseModel
{
    public string? Description { get; set; }

    public string Namespace { get; set; } = null!;

    public string ClassName { get; set; } = null!;

    public ICollection<PropertyDto> Properties { get; set; } = new List<PropertyDto>();
}