using AnyOfTypes;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;
using RestEaseClientGenerator.Models.Internal;
using RestEaseClientGenerator.Settings;

namespace RestEaseClientGenerator.Mappers;

internal class ModelsMapper : BaseMapper
{
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
            var result = _schemaMapper.MapSchema(_interface, entry.Value, string.Empty, entry.Key, entry.Value.Nullable, true, _openApiSpecVersion, _directory);

            if (result.IsSecond)
            {
                // It's a Model
                yield return new RestEaseModel
                {
                    Description = entry.Value.Description,
                    Namespace = Settings.Namespace,
                    ClassName = MakeValidClassName(entry.Key),
                    Properties = result.Second
                };
            }

            if (result.IsFirst && result.First.Type.Contains("[]"))
            {
                // It's a Array
                yield return new RestEaseModel
                {
                    Description = entry.Value.Description,
                    Namespace = Settings.Namespace,
                    ClassName = MakeValidClassName(entry.Key),
                    Properties = new List<PropertyDto> { result.First }
                };
            }
        }
    }
}