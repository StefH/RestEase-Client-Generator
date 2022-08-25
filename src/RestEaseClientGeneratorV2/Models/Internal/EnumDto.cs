using RestEaseClientGeneratorV2.Models.Internal;

namespace RestEaseClientGenerator.Models.Internal;

internal record EnumDto(string Type, string Name, bool Nullable, IList<string> Values, string? Description = null) : BaseDto(Type, Description)
{
    public override string ToString()
    {
        return $"{Type} {Name}";
    }

    public PropertyDto ToPropertyDto(bool nullable)
    {
        return new PropertyDto(Type, Name, nullable, Description);
    }
}