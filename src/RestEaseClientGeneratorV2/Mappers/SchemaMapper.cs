using System.Diagnostics.CodeAnalysis;
using System.IO;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.Mappers;
using RestEaseClientGenerator.Models.Internal;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;
using RestEaseClientGenerator.Types.Internal;
using RestEaseClientGenerator.Utils;
using RestEaseClientGeneratorV2.Models.Internal;

namespace RestEaseClientGeneratorV2.Mappers;

internal class SchemaMapper : BaseMapper
{
    private readonly GeneratorSettings _settings;
    private readonly InternalDto _dto;

    public SchemaMapper(GeneratorSettings settings, InternalDto dto) : base(settings)
    {
        _settings = settings;
        _dto = dto;
    }

    public BaseDto Map(string key, string parentName, OpenApiSchema schema, bool isProperty, string? directory)
    {
        var name = key.ToPascalCase();

        if (key == "Display")
        {
            int d = 8;
        }

        if (isProperty && TryGetReferenceId(schema, directory, out var referenceId))
        {
            return MapReference(referenceId, schema, directory);
        }

        switch (schema.GetSchemaType())
        {
            case SchemaType.Array:
                return MapArray(name, parentName, schema, directory);

            case SchemaType.Boolean:
                return MapBoolean(name, schema);

            case SchemaType.File:
                throw new ArgumentOutOfRangeException();

            case SchemaType.Integer:
                return MapInteger(name, schema);

            case SchemaType.Number:
                return MapNumber(name, schema);

            case SchemaType.Object:
                return MapObject(name, parentName, schema, isProperty, directory);

            case SchemaType.String:
                return MapString(name, parentName, schema);

            case SchemaType.Unknown:
                return MapUnknown(name, parentName, schema, isProperty, directory);

            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private PropertyDto MapArray(string name, string parentName, OpenApiSchema schema, string? directory)
    {
        var arrayItem = Map(name, name, schema.Items, true, directory);
        string? type;
        switch (arrayItem)
        {
            case PropertyDto propertyDto:
                type = propertyDto.Type;
                break;

            case ModelDto modelDto:
                type = BuildModelType(modelDto.Type);
                var updatedModel = modelDto with
                {
                    Type = type,
                    Description = schema.Description
                };
                AddToExtraModels(updatedModel, _dto.Models);
                break;

            case EnumDto enumDto:
                type = enumDto.Type;
                break;

            case ReferenceDto referenceDto:
                type = referenceDto.Type;
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

    private BaseDto MapObject(string name, string parentName, OpenApiSchema schema, bool isProperty, string?  directory)
    {
        if (!schema.Properties.Any())
        {
            return new PropertyDto("object", name, schema.Nullable, null, schema.Description);
        }

        var properties = new List<PropertyDto>();
        foreach (var schemaProperty in schema.Properties)
        {
            var propertyName = schemaProperty.Key.ToPascalCase();

            if (propertyName == "OverriddenProperties")
            {
                int y = 9;
            }

            var result = Map(propertyName, parentName, schemaProperty.Value, true, directory);

            switch (result)
            {
                case PropertyDto propertyDto:
                    properties.Add(propertyDto);
                    break;

                case ModelDto modelDto:
                    properties.Add(new PropertyDto(modelDto.Type, propertyName, schema.Nullable, modelDto.Description));
                    break;

                case EnumDto enumDto:
                    properties.Add(new PropertyDto(enumDto.Type, propertyName, schema.Nullable, enumDto.Description));
                    break;

                case ReferenceDto referenceDto:
                    properties.Add(referenceDto.ToPropertyDto(propertyName, schema.Nullable));
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        var model =  new ModelDto(name, name, properties, schema.Description);

        // In case this object is a property, which means that it's defined 'inline', add it to the models.
        if (isProperty)
        {
            _dto.AddModel(model);
        }

        return model;
    }

    private BaseDto MapString(string name, string parentName, OpenApiSchema schema)
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

    private BaseDto MapUnknown(string name, string parentName, OpenApiSchema schema, bool isProperty, string? directory)
    {
        if (isProperty && TryGetReferenceId(schema, directory, out var referenceId))
        {
            // It's a reference
            return MapReference(referenceId, schema, directory);
        }

        if (schema.Properties.Any())
        {
            // It's an inline object-model
            var @object = MapObject(name, parentName, schema, isProperty, directory);
            if (@object is ModelDto)
            {
                return @object;
            }

            throw new ArgumentOutOfRangeException();
        }

        var allOfOrAnyOfSchemas = schema.AllOf.Union(schema.AnyOf).ToList();
        if (allOfOrAnyOfSchemas.Count == 1)
        {
            return Map(name, parentName, allOfOrAnyOfSchemas[0], true, directory);
        }

        if (allOfOrAnyOfSchemas.Count > 1)
        {
            var properties = new List<PropertyDto>();
            foreach (var childSchema in allOfOrAnyOfSchemas)
            {
                //var childName = TryGetReferenceId(childSchema, out var id) ? id : string.Empty;
                var childModel = Map(string.Empty, parentName, childSchema, true, directory);
                switch (childModel)
                {
                    case PropertyDto propertyDto:
                        properties.Add(propertyDto);
                        break;

                    case ModelDto modelDto:
                        properties.AddRange(modelDto.Properties);
                        break;

                    case ReferenceDto:
                        // skip
                        //properties.Add(referenceDto.ToPropertyDto("todo", schema.Nullable));
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return new ModelDto(BuildModelType(name), name, properties, schema.Description);
        }

        // It's not an inline-object (no properties) and does not have AllOf or AnyOf, so just assume it's an object
        return new PropertyDto("object", name, schema.Nullable, null, schema.Description);
    }

    private BaseDto MapReference(ReferenceDto referenceId, OpenApiSchema schema, string? directory)
    {
        string referenceType = "object";
        if (schema.GetSchemaType() is SchemaType.Object or SchemaType.Unknown)
        {
            if (!referenceId.@internal)
            {
                return referenceId;
            }

            if (schema.Properties.Any())
            {
                return referenceId; //referenceType = FixReservedType(referenceId.ToPascalCase());
            }

            throw new InvalidOperationException();

            if (referenceType == "Requirements")
            {
                int tt = 9;
            }
        }
        else
        {
            if (schema.Description?.StartsWith("Requirements the users has ((dis)") == true)
            {
                int y = 9;
            }

            var result = Map(string.Empty, string.Empty, schema, false, directory);
            referenceType = result.Type;

            if (referenceType == "Requirements")
            {
                int tt = 9;
            }

            if (referenceType == "Sku")
            {
                int tt = 9;
            }
        }

        return new ReferenceDto(referenceType, false, schema.Description);
    }

    private void AddToExtraModels(ModelDto model, ICollection<ModelDto> extraModels)
    {
        if (!extraModels.Any(m => m.ClassName == model.ClassName && m.Type == model.Type))
        {
            extraModels.Add(model);
        }
    }

    private bool TryGetReferenceId(OpenApiSchema schema, string? directory, [NotNullWhen(true)] out ReferenceDto? id)
    {
        switch (schema.Reference)
        {
            case { IsLocal: true }:
                id = new ReferenceDto(FixReservedType(schema.Reference.Id.ToPascalCase()), true);
                return true;

            case { IsExternal: true }:
                id = new ExternalReferenceMapper(Settings, _dto).MapReference(schema.Reference, directory);
                return true;

            default:
                id = default;
                return false;
        }
    }

    private string BuildModelType(string type)
    {
        return $"{type}{_settings.InlineModelPostFix}";
    }

    private string FixReservedType(string type)
    {
        return IdentifierUtils.IsReserved(type) ? $"{_settings.ModelsNamespace}.{type}" : type;
    }
}