using OpenApi.RestEase.Generator.Types;

namespace OpenApi.RestEase.Generator.Models.Internal;

internal class RestEaseSecurityDefinition
{
    public SecurityDefinitionType Type { get; set; }

    public string Name { get; set; }

    public string IdentifierName { get; set; }
}