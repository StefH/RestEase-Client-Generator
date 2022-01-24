namespace RestEaseClientGenerator.Models.Internal;

internal record InternalDto
(
    RestEaseInterface Interface,
    IList<RestEaseModel> Models,
    IList<RestEaseEnum> Enums
    //IDictionary<string, OpenApiParameter> Parameters
);