using RestEaseClientGeneratorV2.Models.Internal;

namespace RestEaseClientGenerator.Models.Internal;

internal record PropertyDto(string Type, string Name, bool Nullable, string? ArrayItemType = null, string? Description = null, PropertyDto? Extends = null) : BaseDto(Type, Description)
{
    public override string ToString()
    {
        string nullable = Nullable ? "?" : string.Empty;
        return $"{Type}{nullable} {Name}";
    }
}