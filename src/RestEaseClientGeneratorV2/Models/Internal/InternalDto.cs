namespace RestEaseClientGenerator.Models.Internal;

internal record InternalDto
(
    RestEaseInterface? Interface,
    IReadOnlyList<ModelDto> Models,
    IReadOnlyList<EnumDto> Enums
    //IDictionary<string, OpenApiParameter> Parameters
);