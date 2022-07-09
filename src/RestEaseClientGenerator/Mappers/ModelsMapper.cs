using AnyOfTypes;
using Microsoft.OpenApi;
using System.Collections.Generic;
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

    public IReadOnlyList<AnyOf<RestEaseModel, RestEaseEnum>> Map(IDictionary<string, OpenApiSchema> schemas)
    {
        var entries = schemas.OrderBy(s => s.Key).ToList();
        var list = new List<AnyOf<RestEaseModel, RestEaseEnum>>();

        foreach (var entry in entries)
        {
            if (entry.Key == "geojsonPoint")
            {
                int yuuu = 8;
            }

            var result = _schemaMapper.MapSchema(_interface, entry.Value, string.Empty, entry.Key, entry.Value.Nullable, true, _openApiSpecVersion, _directory);

            if (result.IsSecond)
            {
                // It's a Model
                list.Add(new RestEaseModel
                {
                    Description = entry.Value.Description,
                    Namespace = Settings.Namespace,
                    ClassName = MakeValidClassName(entry.Key),
                    Properties = result.Second
                });
            }

            if (result.IsFirst)
            {
                int vvvv = 9;
            }

            if (result.IsFirst && result.First.ArrayItemType != null)
            {
                // Class is an Array or extends an Array
                list.Add(new RestEaseModel
                {
                    Description = entry.Value.Description,
                    Namespace = Settings.Namespace,
                    ClassName = MakeValidClassName(entry.Key),
                    Properties = new List<PropertyDto> { result.First }
                });
            }
        }

        return list;
    }
}