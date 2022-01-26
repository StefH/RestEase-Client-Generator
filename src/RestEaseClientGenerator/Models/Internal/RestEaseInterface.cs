using Microsoft.OpenApi.Models;

namespace RestEaseClientGenerator.Models.Internal;

internal class RestEaseInterface
{
    public string Name { get; set; }

    public string Namespace { get; set; }

    public string Summary { get; set; }

    public List<RestEaseInterfaceHeader> VariableHeaders { get; set; } = new List<RestEaseInterfaceHeader>();

    public List<RestEaseInterfaceQueryParameter> ConstantQueryParameters { get; set; } = new List<RestEaseInterfaceQueryParameter>();

    public ICollection<RestEaseInterfaceMethodDetails> Methods { get; set; } = new List<RestEaseInterfaceMethodDetails>();

    public ICollection<RestEaseModel> ExtraModels { get; set; } = new List<RestEaseModel>();

    public ICollection<RestEaseEnum> ExtraEnums { get; set; } = new List<RestEaseEnum>();

    public IDictionary<string, OpenApiParameter> Parameters { get; set; } = new Dictionary<string, OpenApiParameter>();

    public OpenApiDocument OpenApiDocument { get; set; } = null!;
}