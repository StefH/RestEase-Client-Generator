using Microsoft.OpenApi.Models;
using RestEaseClientGenerator.Types;

namespace RestEaseClientGenerator.Models.Internal;

public class RestEaseParameter
{
    public ParameterLocation? ParameterLocation { get; set; }

    public string Identifier { get; set; }

    public string ValidIdentifier { get; set; }

    public string? IdentifierWithTypePascalCase { get; set; }

    public string IdentifierWithType { get; set; }

    public SchemaType SchemaType { get; set; }

    public SchemaFormat SchemaFormat { get; set; }

    public string IdentifierWithRestEase { get; set; }

    public string Summary { get; set; }

    public bool Required { get; set; }

    public bool IsSpecial { get; set; }
}