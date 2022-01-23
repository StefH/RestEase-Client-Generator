using Microsoft.OpenApi.Models;
using RestEaseClientGenerator.Types;

namespace RestEaseClientGenerator.Models.Internal;

internal class MediaTypeInfo
{
    public SupportedContentType Key { get; set; }

    public string ContentType { get; set; }

    public OpenApiMediaType Value { get; set; }
}