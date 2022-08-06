using RestEaseClientGeneratorV2.Models.Internal;

namespace RestEaseClientGenerator.Models.Internal;

internal record ModelDto(string Type, string ClassName, IList<PropertyDto> Properties, string? Description = null, ModelDto? Extends = null) : BaseDto(Type, Description)
{
    public override string ToString()
    {
        return $"{Type} {ClassName}";
    }

    //public PropertyDto ToPropertyDto(string propertyName, bool nullable)
    //{
    //    return new PropertyDto(Type, propertyName, nullable, null, Description);
    //}
}