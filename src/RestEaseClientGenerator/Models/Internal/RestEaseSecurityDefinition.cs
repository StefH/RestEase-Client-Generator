using RestEaseClientGenerator.Types;

namespace RestEaseClientGenerator.Models.Internal;

internal class RestEaseSecurityDefinition
{
    public SecurityDefinitionType Type { get; set; }

    public string Name { get; set; }

    public string IdentifierName { get; set; }
}