using RestEaseClientGenerator.Types;

namespace RestEaseClientGenerator.Models.Internal;

internal record RequestDetails
{
    public SupportedContentType? DetectedContentType { get; set; }

    public ICollection<string>? ContentTypes { get; set; }

    public bool IsExtension { get; set; }
}