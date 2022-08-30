using Microsoft.OpenApi.Models;
using RestEaseClientGeneratorV2.Models.Internal;

namespace RestEaseClientGenerator.Models.Internal;

internal record ReferenceDto(string Type, string Id, bool @internal, string? Description = null) : BaseDto(Type, Id, Description)
{
    //public override string ToString()
    //{
    //    string nullable = Nullable ? "?" : string.Empty;
    //    return $"{Id}{nullable} {Name}";
    //}

    public PropertyDto ToPropertyDto(string propertyName, bool nullable)
    {
        return new PropertyDto(Type, propertyName, nullable, Description);
    }
}