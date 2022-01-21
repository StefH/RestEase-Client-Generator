using AnyOfTypes;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;
using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.Models.Internal;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;

namespace RestEaseClientGenerator.Mappers;

internal class ModelsMapper : BaseMapper
{
    // private readonly SchemaType[] _schemaTypes = { SchemaType.Object, SchemaType.Unknown };

    private readonly RestEaseInterface _interface;
    private readonly SchemaMapper _schemaMapper;
    private readonly OpenApiSpecVersion _openApiSpecVersion;
    private readonly string? _directory;

    public ModelsMapper(
        RestEaseInterface @interface,
        GeneratorSettings settings,
        SchemaMapper schemaMapper,
        OpenApiSpecVersion openApiSpecVersion,
        string? directory) : base(settings)
    {
        _interface = @interface;
        _schemaMapper = schemaMapper;
        _openApiSpecVersion = openApiSpecVersion;
        _directory = directory;
    }

    public IEnumerable<AnyOf<RestEaseModel, RestEaseEnum>> Map(IDictionary<string, OpenApiSchema> schemas)
    {
        var validSchemas = schemas
            .OrderBy(s => s.Key);
           // .Where(s => _schemaTypes.Contains(s.Value.GetSchemaType()));

        foreach (var x in validSchemas)
        {
            var properties = _schemaMapper.MapSchema(_interface, x.Value, x.Key, x.Value.Nullable, true, _openApiSpecVersion, _directory);

            if (properties.IsFirst)
            {
                // It's an enum
                yield return new RestEaseEnum
                {
                    Namespace = Settings.Namespace,
                    EnumName = MakeValidModelName(x.Key)
                };
            }

            if (properties.IsSecond)
            {
                yield return new RestEaseModel
                {
                    Namespace = Settings.Namespace,
                    ClassName = MakeValidModelName(x.Key),
                    Properties = properties.Second
                };
            }
        }
    }
}