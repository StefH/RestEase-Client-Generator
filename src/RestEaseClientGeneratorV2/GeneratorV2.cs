using AnyOfTypes;
using Microsoft.OpenApi.Readers;
using RestEaseClientGenerator.Models.Internal;
using RestEaseClientGenerator.Settings;
using RestEaseClientGeneratorV2.Mappers;

namespace RestEaseClientGeneratorV2;

public class GeneratorV2
{
    public void Map(string path)
    {
        var reader = new OpenApiStreamReader();
        var document = reader.Read(File.OpenRead(path), out var diagnostic);

        var schemas = document.Components.Schemas.OrderBy(s => s.Key).ToList();

        var mapper = new SchemaMapper(new GeneratorSettings
        {

        });

        var models = new List<ModelDto>();
        var enums = new List<EnumDto>();
        foreach (var schema in schemas)
        {
            var propertyOrModelOrEnum = mapper.Map(schema.Key, string.Empty, schema.Value, models);
            switch (propertyOrModelOrEnum.CurrentType)
            {
                case AnyOfType.First:
                    if (propertyOrModelOrEnum.First.ArrayItemType != null)
                    {
                        // it's an array
                        int vvv = 9;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    break;

                case AnyOfType.Second:
                    models.Add(propertyOrModelOrEnum.Second);
                    break;

                case AnyOfType.Third:
                    enums.Add(propertyOrModelOrEnum.Third);
                    break;
            }
        }
        
        int y = 9;
    }
}