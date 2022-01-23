namespace OpenApi.RestEase.Generator.Models.Internal;

public record PropertyDto(string Type, string Name, string? Description = null, string? Extends = null)
{
    public override string ToString()
    {
        return $"{Type} {Name}";
    }
}