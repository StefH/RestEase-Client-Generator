using RestEaseClientGeneratorV2.Models.Internal;

namespace RestEaseClientGenerator.Models.Internal;

internal record ModelDto(string Type, string Name, IList<PropertyDto> Properties, string? Description = null) : BaseDto(Type, Name, Description)
{
    public IReadOnlyList<BaseDto>? Extends { get; set; }

    public override string ToString()
    {
        return $"{Type} {Name}";
    }

    //public PropertyDto ToPropertyDto(string propertyName, bool nullable)
    //{
    //    return new PropertyDto(Type, propertyName, nullable, null, Description);
    //}
}