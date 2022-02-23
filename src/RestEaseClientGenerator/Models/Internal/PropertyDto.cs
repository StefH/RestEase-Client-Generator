namespace RestEaseClientGenerator.Models.Internal;

internal record PropertyDto(string Type, string Name, bool IsArray = false, string? Description = null, PropertyDto? Extends = null)
{
    public override string ToString()
    {
        return $"{Type} {Name}";
    }
}