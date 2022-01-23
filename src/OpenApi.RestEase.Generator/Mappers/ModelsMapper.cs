using AnyOfTypes;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;
using OpenApi.RestEase.Generator.Models.Internal;
using OpenApi.RestEase.Generator.Settings;

namespace OpenApi.RestEase.Generator.Mappers;

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
        foreach (var entry in schemas.OrderBy(s => s.Key))
        {
            var properties = _schemaMapper.MapSchema(_interface, entry.Value, string.Empty, entry.Key, entry.Value.Nullable, true, _openApiSpecVersion, _directory);

            //if (properties.IsFirst)
            //{
            //    throw new InvalidOperationException();
            //    // It's an Enum
            //    yield return new RestEaseEnum
            //    {
            //        Namespace = Settings.Namespace,
            //        EnumName = MakeValidModelName(entry.Key),
            //        Values = null
            //    };
            //}

            if (properties.IsSecond)
            {
                // It's a Model
                yield return new RestEaseModel
                {
                    Description = entry.Value.Description,
                    Namespace = Settings.Namespace,
                    ClassName = MakeValidModelName(entry.Key),
                    Properties = properties.Second
                };
            }
        }
    }
}