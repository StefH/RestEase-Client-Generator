using RestEaseClientGeneratorV2.Models.Internal;

namespace RestEaseClientGenerator.Models.Internal;

internal record PropertyDto(string Type, string Name, bool Nullable, string? Description = null) : BaseDto(Type, Name, Description)
{
    public string? ArrayItemType { get; set; }

    public override string ToString()
    {
        string nullable = Nullable ? "?" : string.Empty;
        return $"{Type}{nullable} {Name}";
    }
}