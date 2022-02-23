namespace RestEaseClientGenerator.Models.Internal;

internal record PropertyDto(string Type, string Name, string? ArrayItemType = null, string? Description = null, PropertyDto? Extends = null)
{
    public override string ToString()
    {
        return $"{Type} {Name}";
    }
}