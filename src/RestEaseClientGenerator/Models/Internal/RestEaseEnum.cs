using RestEaseClientGenerator.Types;

namespace RestEaseClientGenerator.Models.Internal;

public class RestEaseEnum
{
    public string Namespace { get; set; }

    public string EnumName { get; set; }

    public string BaseName { get; set; }

    public ICollection<string>? Values { get; set; } // Can be null in case EnumType is not Enum

    public EnumType EnumType { get; set; }
}