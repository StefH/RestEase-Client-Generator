namespace RestEaseClientGenerator.Models.Internal;

internal record RestEaseInterfaceHeader(string ValidIdentifier, string Name)
{
    public string? Value { get; set; }
}