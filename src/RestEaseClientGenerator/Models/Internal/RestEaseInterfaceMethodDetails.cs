using RestEaseClientGenerator.Types;

namespace RestEaseClientGenerator.Models.Internal;

internal class RestEaseInterfaceMethodDetails
{
    public string Summary { get; set; }

    public ICollection<RestEaseSummaryParameter> SummaryParameters { get; set; } = new List<RestEaseSummaryParameter>();

    public ICollection<string> Headers { get; set; } = new List<string>();

    public RestEaseAttribute RestEaseAttribute { get; set; }

    public RestEaseInterfaceMethod RestEaseMethod { get; set; }

    public RestEaseInterfaceMethodDetails? ExtensionMethodDetails { get; set; }

    public SupportedContentType? ExtensionMethodContentType { get; set; }

    public ICollection<RestEaseParameter> ExtensionMethodParameters { get; set; }
}