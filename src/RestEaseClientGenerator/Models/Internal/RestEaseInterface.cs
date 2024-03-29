using Microsoft.OpenApi.Models;

namespace RestEaseClientGenerator.Models.Internal;

internal record RestEaseInterface(OpenApiDocument OpenApiDocument, string Name, string Namespace, string Summary)
{
    public List<RestEaseInterfaceHeader> VariableHeaders { get; set; } = new();

    public List<RestEaseInterfaceQueryParameter> ConstantQueryParameters { get; set; } = new();

    public List<RestEaseInterfaceMethodDetails> Methods { get; set; } = new();

    public List<RestEaseModel> ExtraModels { get; set; } = new();

    public List<RestEaseEnum> ExtraEnums { get; set; } = new();
}