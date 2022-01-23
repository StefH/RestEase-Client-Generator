using Microsoft.OpenApi.Models;
using OpenApi.RestEase.Generator.Types;

namespace OpenApi.RestEase.Generator.Models.Internal;

internal class MediaTypeInfo
{
    public SupportedContentType Key { get; set; }

    public string ContentType { get; set; }

    public OpenApiMediaType Value { get; set; }
}