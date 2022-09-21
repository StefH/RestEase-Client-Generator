using System.Diagnostics.CodeAnalysis;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.Mappers;
using RestEaseClientGenerator.Models.Internal;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;
using RestEaseClientGenerator.Types.Internal;
using RestEaseClientGenerator.Utils;
using RestEaseClientGeneratorV2.Extensions;
using RestEaseClientGeneratorV2.Models.Internal;
using RestEaseClientGeneratorV2.Utils;

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

    public BaseDto Map(string key, string parentName, OpenApiSchema schema, bool isProperty, string path, CasingType casingType = CasingType.Pascal)
    {
        var name = key.Case(casingType);

        if (key == "PrivateEndpointConnectionProperties")
        {
            int c = 9;
        }

        if (isProperty && TryGetReferenceId(schema, path, casingType, out var referenceId))
        {
            return MapReference(referenceId, schema, path, casingType);
        }

        switch (schema.GetSchemaType())
        {
            case SchemaType.Array:
                return MapArray(name, parentName, schema, path);

            case SchemaType.Boolean:
                return MapBoolean(name, schema);

            case SchemaType.File:
                return MapFile(name, schema);

            case SchemaType.Integer:
                return MapInteger(name, parentName, schema, path, casingType);

            case SchemaType.Number:
                return MapNumber(name, schema);

            case SchemaType.Object:
                return MapObject(name, parentName, schema, isProperty, path, casingType);

            case SchemaType.String:
                return MapString(name, parentName, schema, path, casingType);

            case SchemaType.Unknown:
                return MapUnknown(name, parentName, schema, isProperty, path, casingType);

            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private PropertyDto MapArray(string name, string parentName, OpenApiSchema schema, string path)
    {
        var arrayItem = Map(name, parentName, schema.Items, true, path);
        string? arrayItemType;
        switch (arrayItem)
        {
            case PropertyDto propertyDto:
                arrayItemType = propertyDto.Type;
                break;

            case ModelDto modelDto:
                arrayItemType = BuildModelType(modelDto.Type);
                var updatedModel = modelDto with
                {
                    Type = arrayItemType,
                    Description = schema.Description
                };
                AddToExtraModels(updatedModel, _dto.Models);
                break;

            case EnumDto enumDto:
                arrayItemType = enumDto.Type;
                break;

            case ReferenceDto referenceDto:
                arrayItemType = referenceDto.Type;
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }

        return new PropertyDto(ArrayTypeMapper.Map(_settings.ArrayType, arrayItemType), name, schema.Nullable, schema.Description)
        {
            ArrayItemType = arrayItemType
        };
    }

    private static PropertyDto MapBoolean(string name, OpenApiSchema schema)
    {
        return new PropertyDto("bool", name, schema.Nullable, schema.Description);
    }

    private PropertyDto MapFile(string name, OpenApiSchema schema)
    {
        return Settings.MultipartFormDataFileType switch
        {
            MultipartFormDataFileType.Stream => new PropertyDto("System.IO.Stream", name, false, schema.Description),
            _ => new PropertyDto("byte[]", name, false, schema.Description)
        };
    }

    private BaseDto MapInteger(string name, string parentName, OpenApiSchema schema, string path, CasingType casingType)
    {
        var type = schema.GetSchemaFormat() switch
        {
            SchemaFormat.Int64 => typeof(long),
            _ => typeof(int)
        };

        if (schema.Enum != null && schema.Enum.Any())
        {
            return MapEnum(type, name, parentName, schema, path, casingType);
        }

        return new PropertyDto(type.ToString(), name, schema.Nullable, schema.Description);
    }

    private static PropertyDto MapNumber(string name, OpenApiSchema schema)
    {
        return schema.GetSchemaFormat() switch
        {
            SchemaFormat.Float => new PropertyDto("float", name, schema.Nullable, schema.Description),
            _ => new PropertyDto("double", name, schema.Nullable, schema.Description)
        };
    }

    private BaseDto MapObject(string name, string parentName, OpenApiSchema schema, bool isProperty, string path, CasingType casingType)
    {
        var allOfOrAnyOfSchemas = schema.GetAllOfAndAnyOf();
        if (!schema.Properties.Any() && !allOfOrAnyOfSchemas.Any())
        {
            return new PropertyDto("object", name, schema.Nullable, schema.Description);
        }

        var properties = new List<PropertyDto>();
        foreach (var schemaProperty in schema.Properties)
        {
            var propertyName = schemaProperty.Key.ToPascalCase();

            var result = Map(propertyName, name, schemaProperty.Value, true, path);

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

        var model = new ModelDto(name, name, properties, schema.Description);

        if (allOfOrAnyOfSchemas.Any())
        {
            // This object extends another
            var extendList = new List<BaseDto>();
            foreach (var extends in allOfOrAnyOfSchemas)
            {
                if (TryGetReferenceId(extends, path, casingType, out var referenceId))
                {
                    extendList.Add(MapReference(referenceId, schema, path, casingType));
                }
            }

            model.Extends = extendList;
        }

        // In case this object is a property, which means that it's defined 'inline', add it to the models.
        if (isProperty)
        {
            _dto.AddModel(model);
        }

        return model;
    }

    private BaseDto MapString(string name, string parentName, OpenApiSchema schema, string path, CasingType casingType)
    {
        switch (schema.GetSchemaFormat())
        {
            case SchemaFormat.Date:
            case SchemaFormat.DateTime:
                return new PropertyDto("DateTime", name, schema.Nullable, schema.Description);

            case SchemaFormat.Byte:
            case SchemaFormat.Binary:
                return _settings.ApplicationOctetStreamType switch
                {
                    ApplicationOctetStreamType.Stream => new PropertyDto("System.IO.Stream", name, schema.Nullable, schema.Description),
                    _ => new PropertyDto("byte[]", name, schema.Nullable, schema.Description)
                };

            default:
                if (schema.Enum != null && schema.Enum.Any())
                {
                    if (name == "ExtendedLocationType")
                    {
                        int y = 9;
                    }
                    return MapEnum(typeof(string), name, parentName, schema, path, casingType);
                }

                return new PropertyDto("string", name, schema.Nullable, schema.Description);
        }
    }

    private EnumDto MapEnum(Type type, string name, string parentName, OpenApiSchema schema, string path, CasingType casingType)
    {
        var (enumClassName, enumPostFix) = EnumHelper.GetEnumClassName(_settings, name, parentName, casingType);

        List<string> enumValues;
        switch (Type.GetTypeCode(type))
        {
            case TypeCode.Int32:
                enumValues = schema.Enum.OfType<OpenApiInteger>().Select(x => x.Value.ToString()).ToList();
                break;

            case TypeCode.Int64:
                enumValues = schema.Enum.OfType<OpenApiLong>().Select(x => x.Value.ToString()).ToList();
                break;

            case TypeCode.String:
                enumValues = schema.Enum.OfType<OpenApiString>()
                    .SelectMany(str => str.Value.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()))
                    .ToList();
                break;

            default:
                throw new NotSupportedException();
        }

        var enumType = _settings.PreferredEnumType == EnumType.Enum ? enumClassName : type.GetFriendlyName();

        var @enum = new EnumDto(enumType, enumClassName, enumPostFix, schema.Nullable, enumValues, schema.Description);

        _dto.AddEnum(@enum, path);

        return @enum;
    }

    private BaseDto MapUnknown(string name, string parentName, OpenApiSchema schema, bool isProperty, string path, CasingType casingType)
    {
        if (isProperty && TryGetReferenceId(schema, path, casingType, out var referenceId))
        {
            // It's a reference
            return MapReference(referenceId, schema, path, casingType);
        }

        if (schema.Properties.Any())
        {
            var @object = MapObject(name, parentName, schema, isProperty, path, casingType);
            if (@object is ModelDto)
            {
                return @object;
            }

            throw new ArgumentOutOfRangeException();
        }

        var allOfOrAnyOfSchemas = schema.GetAllOfAndAnyOf();
        if (allOfOrAnyOfSchemas.Count == 1)
        {
            return Map(name, parentName, allOfOrAnyOfSchemas[0], true, path);
        }

        if (allOfOrAnyOfSchemas.Count > 1)
        {
            var properties = new List<PropertyDto>();
            foreach (var childSchema in allOfOrAnyOfSchemas)
            {
                var childModel = Map(string.Empty, parentName, childSchema, true, path);
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

            var distinctAnyOfTypes = properties.Select(p => p.Type).Distinct().ToList();
            return new PropertyDto($"AnyOf<{string.Join(", ", distinctAnyOfTypes)}>", name, schema.Nullable, schema.Description);
            //return new ModelDto(BuildModelType(name), name, properties, schema.Description);
        }

        // It's not an inline-object (no properties) and does not have AllOf or AnyOf, so just assume it's an object
        return new PropertyDto("object", name, schema.Nullable, schema.Description);
    }

    private BaseDto MapReference(ReferenceDto referenceId, OpenApiSchema schema, string path, CasingType casingType)
    {
        // string referenceType = "object";
        var schemaType = schema.GetSchemaType();

        if (schemaType is SchemaType.Object or SchemaType.Unknown)
        {
            return referenceId;
        }

        if (schema.Enum is not null)
        {
            return Map(referenceId.Id, string.Empty, schema, false, path, casingType);
        }

        return Map(referenceId.Id, string.Empty, schema, false, path, casingType);
    }

    private void AddToExtraModels(ModelDto model, ICollection<ModelDto> extraModels)
    {
        if (!extraModels.Any(m => m.Name == model.Name && m.Type == model.Type))
        {
            extraModels.Add(model);
        }
    }

    private bool TryGetReferenceId(OpenApiSchema schema, string path, CasingType casingType, [NotNullWhen(true)] out ReferenceDto? referenceDto)
    {

        switch (schema.Reference)
        {
            case { IsLocal: true }:
                var id = MakeValidReferenceId(schema.Reference.Id);
                referenceDto = new ReferenceDto(FixReservedType(schema.Reference.Id.ToPascalCase()), id, true, schema.Description);
                return true;

            case { IsExternal: true }:
                referenceDto = new ExternalReferenceMapper(Settings, _dto).MapReference(schema.Reference, path, casingType);
                return true;

            default:
                referenceDto = default;
                return false;
        }
    }

    private string BuildModelType(string type)
    {
        return type.EndsWith(_settings.InlineModelPostFix) ? type : $"{type}{_settings.InlineModelPostFix}";
    }

    private string FixReservedType(string type)
    {
        return IdentifierUtils.IsReserved(type) ? $"{_settings.ModelsNamespace}.{type}" : type;
    }
}