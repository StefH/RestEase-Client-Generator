using RestEaseClientGeneratorV2.Models.Internal;

namespace RestEaseClientGenerator.Models.Internal;

internal record EnumDto(string Type, string ClassName, string PostFix, bool Nullable, IReadOnlyList<object> Values, string? Description = null) : BaseDto(Type, string.Concat(ClassName, PostFix), Description)
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