using Microsoft.OpenApi.Models;
using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.Types.Internal;
using RestEaseClientGeneratorV2.Models.Internal;

namespace RestEaseClientGenerator.Models.Internal;

internal class RestEaseParameter
{
    public ParameterLocation? ParameterLocation { get; set; }

    public string Identifier { get; set; }

    public string ValidIdentifier { get; set; }

    public PropertyDto IdentifierWithTypePascalCase => new(IdentifierWithType.Type, IdentifierWithType.Name.ToPascalCase(), IsNullable);

    public BaseDto IdentifierWithType { get; set; }

    public string IdentifierRestEasePrefix { get; set; }

    public bool IsNullPostfix { get; set; }

    public SchemaType SchemaType { get; set; }

    public SchemaFormat SchemaFormat { get; set; }

    public string IdentifierWithRestEase => $"{IdentifierRestEasePrefix} {IdentifierWithType}{(IsNullPostfix ? " = null" : string.Empty)}";

    public string Summary { get; set; }

    public bool Required { get; set; }

    public bool IsSpecial { get; set; }

    public bool IsNullable { get; set; }
}