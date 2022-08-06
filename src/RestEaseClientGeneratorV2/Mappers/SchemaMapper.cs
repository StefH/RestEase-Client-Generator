using System.Diagnostics.CodeAnalysis;
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

    public AnyOf<PropertyDto, ModelDto, EnumDto> Map(string key, string parentName, OpenApiSchema schema, ICollection<ModelDto> extraModels)
    {
        var name = key.ToPascalCase();

        switch (schema.GetSchemaType())
        {
            case SchemaType.Array:
                return MapArray(name, parentName, schema, extraModels);

            case SchemaType.Boolean:
                return MapBoolean(name, schema);

            case SchemaType.File:
                throw new ArgumentOutOfRangeException();

            case SchemaType.Integer:
                return MapInteger(name, schema);

            case SchemaType.Number:
                return MapNumber(name, schema);

            case SchemaType.Object:
                var @object = MapObject(name, parentName, schema, extraModels);
                return @object.IsFirst ? @object.First : @object.Second;

            //case SchemaType.Reference:
            //    var reference = MapReference(name, parentName, schema, extraModels);
            //    return reference.IsFirst ? reference.First : reference.Second;

            case SchemaType.String:
                var @string = MapString(name, parentName, schema);
                return @string.IsFirst ? @string.First : @string.Second;

            case SchemaType.Unknown:
                return MapUnknown(name, parentName, schema, extraModels);

            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private PropertyDto MapArray(string name, string parentName, OpenApiSchema schema, ICollection<ModelDto> extraModels)
    {
        var arrayItem = Map(name, name, schema.Items, extraModels);
        string? type;
        switch (arrayItem.CurrentType)
        {
            case AnyOfType.First:
                type = arrayItem.First.Type;
                break;

            case AnyOfType.Second:
                type = BuildModeType(arrayItem.Second.Type);
                var updatedModel = arrayItem.Second with
                {
                    Type = type,
                    Description = schema.Description
                };
                AddToExtraModels(updatedModel, extraModels);
                break;

            case AnyOfType.Third:
                type = arrayItem.Third.Type;
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }

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

    private AnyOf<PropertyDto, ModelDto> MapObject(string name, string parentName, OpenApiSchema schema, ICollection<ModelDto> extraModels)
    {
        var list = new List<PropertyDto>();
        foreach (var schemaProperty in schema.Properties)
        {
            var propertyOrModel = Map(schemaProperty.Key, parentName, schemaProperty.Value, extraModels);
            switch (propertyOrModel.CurrentType)
            {
                case AnyOfType.First:
                    list.Add(propertyOrModel.First);
                    break;

                case AnyOfType.Second:
                    list.Add(propertyOrModel.Second.ToPropertyDto(schema.Nullable));
                    break;

                case AnyOfType.Third:
                    list.Add(propertyOrModel.Third.ToPropertyDto(schema.Nullable));
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
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

    private AnyOf<PropertyDto, ModelDto> MapReference(string name, string parentName, OpenApiSchema schema, ICollection<ModelDto> extraModels)
    {
        return MapObject(name, parentName, schema, extraModels);
    }

    private AnyOf<PropertyDto, ModelDto, EnumDto> MapUnknown(string name, string parentName, OpenApiSchema schema, ICollection<ModelDto> extraModels)
    {
        if (schema.Properties.Any())
        {
            // It's an inline object-model
            var @object = MapObject(name, parentName, schema, extraModels);
            if (@object.IsSecond)
            {
                return @object.Second;
            }

            throw new ArgumentOutOfRangeException();
        }

        var allOfOrAnyOfSchemas = schema.AllOf.Union(schema.AnyOf).ToList();
        if (allOfOrAnyOfSchemas.Count == 1)
        {
            return Map(name, parentName, allOfOrAnyOfSchemas[0], extraModels);
        }

        if (allOfOrAnyOfSchemas.Count > 1)
        {
            var properties = new List<PropertyDto>();
            foreach (var childSchema in allOfOrAnyOfSchemas)
            {
                //var childName = TryGetReferenceId(childSchema, out var id) ? id : string.Empty;
                var childModel = Map(string.Empty, parentName, childSchema, extraModels);
                switch (childModel.CurrentType)
                {
                    case AnyOfType.First:
                        properties.Add(childModel.First);
                        break;

                    case AnyOfType.Second:
                        properties.AddRange(childModel.Second.Properties);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return new ModelDto(BuildModeType(name), name, properties, schema.Description);
        }

        // It's not an inline-object (no properties) and does not have AllOf or AnyOf, so just assume it's an object
        return new PropertyDto("object", name, schema.Nullable, null, schema.Description);
    }

    private void AddToExtraModels(ModelDto model, ICollection<ModelDto> extraModels)
    {
        if (!extraModels.Any(m => m.ClassName == model.ClassName && m.Type == model.Type))
        {
            extraModels.Add(model);
        }
    }

    private bool TryGetReferenceId(OpenApiSchema schema, [NotNullWhen(true)] out string? id)
    {
        switch (schema.Reference)
        {
            case { IsLocal: true }:
                id = schema.Reference.Id;
                return true;

            case { IsExternal: true }:
                throw new NotSupportedException();

            default:
                id = default;
                return false;
        }
    }

    private string BuildModeType(string type)
    {
        return $"{type}{_settings.InlineModelPostFix}";
    }

    private string FixReservedType(string type)
    {
        return IdentifierUtils.IsReserved(type) ? $"{_settings.ModelsNamespace}.{type}" : type;
    }
}