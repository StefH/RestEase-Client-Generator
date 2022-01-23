using Microsoft.OpenApi.Models;
using OpenApi.RestEase.Generator.Models.Internal;
using OpenApi.RestEase.Generator.Settings;

namespace OpenApi.RestEase.Generator.Mappers;

internal class ParametersMapper : BaseMapper
{
    private readonly RestEaseInterface _interface;
    private readonly SchemaMapper _schemaMapper;
    private readonly GeneratorSettings _settings;
    private readonly string? _directory;

    public ParametersMapper(RestEaseInterface @interface, SchemaMapper schemaMapper, GeneratorSettings settings, string? directory)
        : base(settings)
    {
        _interface = @interface;
        _schemaMapper = schemaMapper;
        _settings = settings;
        _directory = directory;
    }

    public IList<OpenApiParameter> Map(OpenApiOperation operation)
    {
        var allOpenApiParameters = operation.Parameters.Where(p => p.Reference is null).ToList();

        foreach (var parameterWithReference in operation.Parameters.Where(p => p.Reference is not null))
        {
            var foundParameter = TryMapParameterReference(_interface, parameterWithReference.Reference, _directory);
            if (foundParameter is not null)
            {
                allOpenApiParameters.Add(foundParameter);
            }
        }

        return allOpenApiParameters;
    }

    private OpenApiParameter? TryMapParameterReference(RestEaseInterface @interface, OpenApiReference reference, string? directory)
    {
        switch (reference)
        {
            case { IsLocal: true }:
                var name = MakeValidReferenceId(reference.Id);
                if (@interface.Parameters.TryGetValue(name, out var parameter))
                {
                    return parameter;
                }

                throw new InvalidOperationException();

            case { IsExternal: true }:
                return new ExternalReferenceMapper(_settings, @interface).MapParameter(reference, directory);

            default:
                return null;
        }
    }
}