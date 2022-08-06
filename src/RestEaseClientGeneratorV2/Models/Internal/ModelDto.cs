namespace RestEaseClientGenerator.Models.Internal;

internal record ModelDto(string Type, string ClassName, IList<PropertyDto> Properties, string? Description = null, ModelDto? Extends = null)
{
    public override string ToString()
    {
        return $"{Type} {ClassName}";
    }

    public PropertyDto ToPropertyDto(bool nullable)
    {
        return new PropertyDto(Type, ClassName, nullable, null, Description);
    }
}