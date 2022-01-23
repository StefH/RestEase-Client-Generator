using OpenApi.RestEase.Generator.Types;

namespace OpenApi.RestEase.Generator.Models.Internal;

internal class RequestDetails
{
    public SupportedContentType? DetectedContentType { get; set; }

    public ICollection<string> ContentTypes { get; set; }

    public bool IsExtension { get; set; }
}