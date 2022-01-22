using AnyOfTypes;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;
using RestEaseClientGenerator.Models.Internal;
using RestEaseClientGenerator.Settings;

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
        if (schemas.ContainsKey("ContainerGroup"))
        {
            int x = 0;
        }

        foreach (var entry in schemas.OrderBy(s => s.Key))
        {
            if (entry.Key == "ContainerGroup")
            {
                int y = 0;
            }

            var properties = _schemaMapper.MapSchema(_interface, entry.Value, entry.Key, entry.Value.Nullable, true, _openApiSpecVersion, _directory);

            if (properties.IsFirst)
            {
                // It's an Enum
                yield return new RestEaseEnum
                {
                    Namespace = Settings.Namespace,
                    EnumName = MakeValidModelName(entry.Key),
                    Values = null,
                    EnumType = Settings.PreferredEnumType
                };
            }

            if (properties.IsSecond)
            {
                // It's a Model
                yield return new RestEaseModel
                {
                    Namespace = Settings.Namespace,
                    ClassName = MakeValidModelName(entry.Key),
                    Properties = properties.Second
                };
            }
        }
    }
}