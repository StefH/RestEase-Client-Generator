using Microsoft.OpenApi.Models;
using RestEaseClientGenerator.Types;

namespace RestEaseClientGenerator.Models.Internal;

internal record MediaTypeInfo(SupportedContentType Key, OpenApiMediaType Value, string ContentType);