namespace RestEaseClientGenerator.Models.Internal;

internal record RestEaseEnum
{
    public string? Description { get; set; }

    public string Namespace { get; set; }

    public string EnumName { get; set; }

    public string BaseName { get; set; }

    public ICollection<string> Values { get; set; }
}