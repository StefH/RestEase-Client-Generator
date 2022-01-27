namespace RestEaseClientGenerator.Models.Internal;

internal record PropertyDto(string Type, string Name, string? Description = null, string? Extends = null)
{
    public override string ToString()
    {
        return $"{Type} {Name}";
    }
}