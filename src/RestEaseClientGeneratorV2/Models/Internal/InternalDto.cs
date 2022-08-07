namespace RestEaseClientGenerator.Models.Internal;

internal record InternalDto
(
    //RestEaseInterface? Interface,
    List<ModelDto> Models,
    List<EnumDto> Enums
    //IDictionary<string, OpenApiParameter> Parameters
);