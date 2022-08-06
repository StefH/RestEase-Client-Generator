using RestEaseClientGeneratorV2.Models.Internal;

namespace RestEaseClientGenerator.Models.Internal;

internal record ReferenceDto(string Type, string? Description = null) : BaseDto(Type, Description)
{
    //public override string ToString()
    //{
    //    string nullable = Nullable ? "?" : string.Empty;
    //    return $"{Id}{nullable} {Name}";
    //}
}