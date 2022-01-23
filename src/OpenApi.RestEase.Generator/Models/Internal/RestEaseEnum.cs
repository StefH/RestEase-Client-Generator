namespace OpenApi.RestEase.Generator.Models.Internal;

public class RestEaseEnum
{
    public string? Description { get; set; }

    public string Namespace { get; set; }

    public string EnumName { get; set; }

    public string BaseName { get; set; }

    public ICollection<string> Values { get; set; }
}