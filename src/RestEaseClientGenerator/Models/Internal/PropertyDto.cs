namespace RestEaseClientGenerator.Models.Internal;

public record PropertyDto(string Type, string Name, string? Extends = null)
{
    public override string ToString()
    {
        return $"{Type} {Name}";
    }
}