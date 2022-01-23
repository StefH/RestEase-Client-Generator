using OpenApi.RestEase.Generator.Types;

namespace OpenApi.RestEase.Generator.Models.Internal;

internal class RestEaseSecurity
{
    public ICollection<RestEaseSecurityDefinition> Definitions { get; set; }

    public SecurityVersionType SecurityVersionType { get; set; }
}