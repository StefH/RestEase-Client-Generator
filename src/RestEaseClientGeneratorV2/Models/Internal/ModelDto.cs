namespace RestEaseClientGenerator.Models.Internal;

internal record ModelDto(string Type, string Name, IList<PropertyDto> Properties, string? Description = null, ModelDto? Extends = null)
{
    public override string ToString()
    {
        return $"{Type} {Name}";
    }

    public PropertyDto ToPropertyDto(bool nullable)
    {
        return new PropertyDto(Type, Name, nullable, null, Description);
    }
}