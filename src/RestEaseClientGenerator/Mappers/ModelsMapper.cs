using AnyOfTypes;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;
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
        //var k = schemas.Where(s => s.Key.StartsWith("LocalU")).ToList()[1];
        //var s = _schemaMapper.MapSchema(_interface, k.Value, k.Key, k.Value.Nullable, true, _openApiSpecVersion,
        //    _directory);

        foreach (var entry in schemas.OrderBy(s => s.Key))
        {
            var properties = _schemaMapper.MapSchema(_interface, entry.Value, entry.Key, entry.Value.Nullable, true, _openApiSpecVersion, _directory);

            //if (properties.IsFirst)
            //{
            //    // It's an enum
            //    //var e = Settings.PreferredEnumType switch
            //    //{
            //    //    EnumType.Enum => MakeValidModelName(entry.Key),
            //    //    EnumType.Integer => $"int{nullable}{nameCamelCase}",
            //    //    EnumType.Object => $"object{nameCamelCase}",
            //    //    _ => $"string{nameCamelCase}"
            //    //};

            //    yield return new RestEaseEnum
            //    {
            //        Namespace = Settings.Namespace,
            //        EnumName = MakeValidModelName(entry.Key),
            //        Values = null,
            //        EnumType = Settings.PreferredEnumType
            //    };
            //}

            if (properties.IsSecond)
            {
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