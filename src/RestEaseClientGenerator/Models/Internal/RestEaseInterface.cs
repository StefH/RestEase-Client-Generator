using Microsoft.OpenApi.Models;

namespace RestEaseClientGenerator.Models.Internal;

internal class RestEaseInterface
{
    public string Name { get; set; }

    public string Namespace { get; set; }

    public string Summary { get; set; }

    public List<RestEaseInterfaceHeader> VariableHeaders { get; set; } = new();

    public List<RestEaseInterfaceQueryParameter> ConstantQueryParameters { get; set; } = new();

    public List<RestEaseInterfaceMethodDetails> Methods { get; set; } = new();

    public List<RestEaseModel> ExtraModels { get; set; } = new();

    public List<RestEaseEnum> ExtraEnums { get; set; } = new();

    public OpenApiDocument OpenApiDocument { get; set; } = null!;
}