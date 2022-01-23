namespace OpenApi.RestEase.Generator.Models.Internal;

public record InternalDto
(
    RestEaseInterface Interface,
    IList<RestEaseModel> Models,
    IList<RestEaseEnum> Enums
    //IDictionary<string, OpenApiParameter> Parameters
);