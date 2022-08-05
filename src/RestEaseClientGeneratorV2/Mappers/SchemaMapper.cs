using AnyOfTypes;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.Models.Internal;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;
using RestEaseClientGenerator.Types.Internal;
using RestEaseClientGenerator.Utils;

namespace RestEaseClientGeneratorV2.Mappers;

internal class SchemaMapper
{
    private readonly GeneratorSettings _settings;

    public SchemaMapper(GeneratorSettings settings)
    {
        _settings = settings;
    }

    public AnyOf<PropertyDto, ModelDto, EnumDto> Map(string key, string parentName, OpenApiSchema schema)
    {
        var name = key.ToPascalCase();

        switch (schema.GetSchemaType())
        {
            case SchemaType.Array:
                return MapArray(name, parentName, schema);

            case SchemaType.Boolean:
                return MapBoolean(name, schema);

            case SchemaType.File:
                throw new ArgumentOutOfRangeException();

            case SchemaType.Integer:
                return MapInteger(name, schema);

            case SchemaType.Number:
                return MapNumber(name, schema);

            case SchemaType.Object:
                var @object = MapObject(name, parentName, schema);
                return @object.IsFirst ? @object.First : @object.Second;

            case SchemaType.String:
                var @string = MapString(name, parentName, schema);
                return @string.IsFirst ? @string.First : @string.Second;

            case SchemaType.Unknown:
                return MapUnknown(name, parentName, schema);

            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private PropertyDto MapArray(string name, string parentName, OpenApiSchema schema)
    {
        var arrayItem = Map(name, name, schema.Items);
        var type = arrayItem.CurrentType switch
        {
            AnyOfType.First => arrayItem.First.Type,
            AnyOfType.Second => arrayItem.Second.Type,
            AnyOfType.Third => arrayItem.Third.Type,
            _ => throw new ArgumentOutOfRangeException()
        };

        return new PropertyDto(ArrayTypeMapper.Map(_settings.ArrayType, type), name, schema.Nullable, type, schema.Description);
    }

    private static PropertyDto MapBoolean(string name, OpenApiSchema schema)
    {
        return new PropertyDto("bool", name, schema.Nullable, null, schema.Description);
    }

    private static PropertyDto MapInteger(string name, OpenApiSchema schema)
    {
        return schema.GetSchemaFormat() switch
        {
            SchemaFormat.Int64 => new PropertyDto("long", name, schema.Nullable, null, schema.Description),
            _ => new PropertyDto("int", name, schema.Nullable, null, schema.Description)
        };
    }

    private static PropertyDto MapNumber(string name, OpenApiSchema schema)
    {
        return schema.GetSchemaFormat() switch
        {
            SchemaFormat.Float => new PropertyDto("float", name, schema.Nullable, schema.Description),
            _ => new PropertyDto("double", name, schema.Nullable, schema.Description)
        };
    }

    private AnyOf<PropertyDto, ModelDto> MapObject(string name, string parentName, OpenApiSchema schema)
    {
        var list = new List<PropertyDto>();
        foreach (var schemaProperty in schema.Properties)
        {
            var propertyOrModel = Map(schemaProperty.Key, parentName, schemaProperty.Value);
            if (propertyOrModel.IsFirst)
            {
                list.Add(propertyOrModel.First);
            }
        }

        return new ModelDto(name, name, list, schema.Description);
    }

    private AnyOf<PropertyDto, EnumDto> MapString(string name, string parentName, OpenApiSchema schema)
    {
        switch (schema.GetSchemaFormat())
        {
            case SchemaFormat.Date:
            case SchemaFormat.DateTime:
                return new PropertyDto("DateTime", name, schema.Nullable, null, schema.Description);

            case SchemaFormat.Byte:
            case SchemaFormat.Binary:
                return _settings.ApplicationOctetStreamType switch
                {
                    ApplicationOctetStreamType.Stream => new PropertyDto("System.IO.Stream", name, schema.Nullable, null, schema.Description),
                    _ => new PropertyDto("byte[]", name, schema.Nullable, null, schema.Description)
                };

            default:
                if (schema.Enum != null && schema.Enum.Any())
                {
                    return MapEnum(name, parentName, schema);
                }

                return new PropertyDto("string", name, schema.Nullable, null, schema.Description);
        }
    }

    private EnumDto MapEnum(string name, string parentName, OpenApiSchema schema)
    {
        var enumNamePostfix = _settings.PreferredEnumType == EnumType.Enum ? "EnumType" : "Constants";
        var enumName = $"{parentName}{name}{enumNamePostfix}".ToPascalCase();
        var enumValues = schema.Enum.OfType<OpenApiString>()
            .SelectMany(str => str.Value.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()))
            .ToList();

        var type = _settings.PreferredEnumType == EnumType.Enum ? enumName : "string";

        return new EnumDto(type, enumName, schema.Nullable, enumValues, schema.Description);
    }

    private AnyOf<PropertyDto, ModelDto, EnumDto> MapUnknown(string name, string parentName, OpenApiSchema schema)
    {
        if (schema.Properties.Any())
        {
            // It's an inline object-model
            var @object = MapObject(name, parentName, schema);
            if (@object.IsSecond)
            {
                return @object.Second;
            }

            throw new ArgumentOutOfRangeException();
        }

        return new PropertyDto("xxx", name, schema.Nullable, null, schema.Description);
    }

    private string FixReservedType(string type)
    {
        return IdentifierUtils.IsReserved(type) ? $"{_settings.ModelsNamespace}.{type}" : type;
    }
}