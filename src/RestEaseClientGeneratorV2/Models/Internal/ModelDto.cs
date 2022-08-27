using RestEaseClientGeneratorV2.Models.Internal;

namespace RestEaseClientGenerator.Models.Internal;

internal record ModelDto(string Type, string ClassName, IList<PropertyDto> Properties, string? Description = null) : BaseDto(Type, Description)
{
    public IReadOnlyList<BaseDto>? Extends { get; set; }

    public override string ToString()
    {
        return $"{Type} {ClassName}";
    }

    //public PropertyDto ToPropertyDto(string propertyName, bool nullable)
    //{
    //    return new PropertyDto(Type, propertyName, nullable, null, Description);
    //}
}