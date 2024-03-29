using AnyOfTypes;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.Models.Internal;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;
using RestEaseClientGenerator.Types.Internal;
using RestEaseClientGenerator.Utils;

namespace RestEaseClientGenerator.Mappers;

internal class SchemaMapper : BaseMapper
{
    public SchemaMapper(GeneratorSettings settings) : base(settings)
    {
    }

    public AnyOf<PropertyDto, IList<PropertyDto>> MapSchema(
        RestEaseInterface @interface,
        OpenApiSchema schema,
        string parentName,
        string? name,
        bool isNullable,
        bool pascalCase,
        OpenApiSpecVersion? openApiSpecVersion,
        string? directory)
    {
        name ??= string.Empty;

        var nameCamelCase = string.IsNullOrEmpty(name) ? string.Empty : $"{(pascalCase ? name.ToPascalCase() : name)}";

        bool nullableForOpenApi20 = openApiSpecVersion == OpenApiSpecVersion.OpenApi2_0 && Settings.GeneratePrimitivePropertiesAsNullableForOpenApi20;
        string nullable = nullableForOpenApi20 || isNullable ? "?" : string.Empty;

        switch (schema.GetSchemaType())
        {
            case SchemaType.Array:
                var listItem = MapSchema(@interface, schema.Items, string.Empty, name, isNullable, pascalCase, openApiSpecVersion, directory);
                if (listItem.IsSecond)
                {
                    // It's a anonymous type
                    return listItem;
                }

                // It's an array-item, return the correct type
                return new PropertyDto(ArrayTypeMapper.Map(Settings.ArrayType, listItem.First.Type), name, listItem.First.Type);

            case SchemaType.Boolean:
                return new PropertyDto($"bool{nullable}", nameCamelCase, null, schema.Description);

            case SchemaType.Integer:
                return schema.GetSchemaFormat() switch
                {
                    SchemaFormat.Int64 => new PropertyDto($"long{nullable}", nameCamelCase, null, schema.Description),
                    _ => new PropertyDto($"int{nullable}", nameCamelCase, null, schema.Description)
                };

            case SchemaType.Number:
                return schema.GetSchemaFormat() switch
                {
                    SchemaFormat.Float => new PropertyDto($"float{nullable}", nameCamelCase, null, schema.Description),
                    _ => new PropertyDto($"double{nullable}", nameCamelCase, null, schema.Description)
                };

            case SchemaType.String:
                switch (schema.GetSchemaFormat())
                {
                    case SchemaFormat.Date:
                    case SchemaFormat.DateTime:
                        return new PropertyDto($"{DateTime}{nullable}", nameCamelCase, null, schema.Description);

                    case SchemaFormat.Byte:
                    case SchemaFormat.Binary:
                        return Settings.ApplicationOctetStreamType switch
                        {
                            ApplicationOctetStreamType.Stream => new PropertyDto("System.IO.Stream", nameCamelCase, null, schema.Description),
                            _ => new PropertyDto("byte[]", nameCamelCase, null, schema.Description)
                        };

                    default:
                        if (schema.Enum != null && schema.Enum.Any())
                        {
                            return MapEnumSchema(@interface, schema, parentName, name, nameCamelCase, nullable);
                        }

                        return new PropertyDto("string", nameCamelCase, null, schema.Description);
                }

            case SchemaType.Object:
            case SchemaType.Unknown:
                var list = new List<PropertyDto>();
                if (schema.AdditionalProperties != null)
                {
                    var additionalResult = MapSchema(@interface, schema.AdditionalProperties, string.Empty, null, schema.AdditionalProperties.Nullable, false, null, directory);
                    if (additionalResult.IsFirst)
                    {
                        var dictionaryType = $"Dictionary<string, {additionalResult.First}>";
                        return new PropertyDto(dictionaryType, parentName, null, schema.Description);
                    }

                    if (additionalResult.IsSecond && additionalResult.Second.Count == 0)
                    {
                        // "Microsoft.AspNetCore.Mvc.ProblemDetails" has "additionalProperties": { }
                        return list;
                    }

                    throw new InvalidOperationException();
                }

                foreach (var schemaProperty in schema.Properties)
                {
                    var openApiSchema = schemaProperty.Value;
                    var objectName = pascalCase ? schemaProperty.Key.ToPascalCase() : schemaProperty.Key;

                    var property = TryMapProperty(@interface, openApiSpecVersion, openApiSchema, name, objectName, directory);
                    switch (property.Type)
                    {
                        case PropertyType.Normal when property.Result.IsFirst:
                            list.Add(property.Result.First);
                            break;

                        case PropertyType.Normal:
                            list.Add(new PropertyDto(property.TypeName, objectName, null, openApiSchema.Description));
                            break;

                        case PropertyType.Reference:
                            list.Add(property.Result.First);
                            break;
                    }
                }

                foreach (var allOrAny in schema.AllOf.Union(schema.AnyOf))
                {
                    var property = TryMapProperty(@interface, openApiSpecVersion, allOrAny, name, string.Empty, directory);
                    switch (property.Type)
                    {
                        case PropertyType.Reference:
                            list.Add(new PropertyDto("not-used", "not-used", null, allOrAny.Description, property.Result.First));
                            break;

                        case PropertyType.Normal when property.Result.IsFirst:
                            list.Add(property.Result.First);
                            break;

                        case PropertyType.Normal:
                            list.AddRange(property.Result.Second.Properties);
                            break;
                    }
                }

                return list;

            case SchemaType.File:
                return Settings.MultipartFormDataFileType switch
                {
                    MultipartFormDataFileType.Stream => new PropertyDto("System.IO.Stream", nameCamelCase, null, schema.Description),
                    _ => new PropertyDto("byte[]", nameCamelCase, null, schema.Description)
                };

            default:
                throw new InvalidOperationException();
        }
    }

    private PropertyDto ToArrayPropertyDto(PropertyDto dto, string? description)
    {
        return dto with
        {
            ArrayItemType = dto.Type,
            Type = ArrayTypeMapper.Map(Settings.ArrayType, dto.Type),
            Description = description ?? dto.Description
        };
    }

    public (PropertyType Type, string TypeName, AnyOf<PropertyDto, RestEaseModel> Result) TryMapProperty(
        RestEaseInterface @interface,
        OpenApiSpecVersion? openApiSpecVersion,
        OpenApiSchema schema,
        string parentName,
        string objectName,
        string? directory)
    {
        if (new[] { SchemaType.Array }.Contains(schema.GetSchemaType()))
        {
            var referencedProperty = TryMapPropertyReference(@interface, schema, objectName, directory);
            if (referencedProperty is not null)
            {
                return (PropertyType.Reference, referencedProperty.Name, ToArrayPropertyDto(referencedProperty, schema.Description));
            }

            var arrayItem = TryMapProperty(@interface, openApiSpecVersion, schema.Items, parentName, objectName, directory);
            if (arrayItem.Result.IsFirst)
            {
                return (PropertyType.Normal, arrayItem.TypeName, ToArrayPropertyDto(arrayItem.Result.First, schema.Description));
            }

            var model = MapInlineModel(@interface, schema, parentName, directory, arrayItem.Result.Second.ClassName);
            return (PropertyType.Normal, arrayItem.Result.Second.ClassName, model);
        }

        if (new[] { SchemaType.Object, SchemaType.Unknown }.Contains(schema.GetSchemaType()))
        {
            var referencedProperty = TryMapPropertyReference(@interface, schema, objectName, directory);
            if (referencedProperty is not null)
            {
                return (PropertyType.Reference, referencedProperty.Name, referencedProperty);
            }

            var className = MakeValidClassName($"{parentName}{objectName}");

            if (schema.AdditionalProperties != null)
            {
                var additionalPropertiesType = TryMapProperty(@interface, openApiSpecVersion, schema.AdditionalProperties, parentName, objectName, directory);
                if (additionalPropertiesType.Result.IsFirst)
                {
                    var dictionaryType = $"Dictionary<string, {additionalPropertiesType.Result.First.Type}>";
                    return (PropertyType.Normal, objectName, new PropertyDto(dictionaryType, objectName, null, schema.Description));
                }
                else
                {
                    var dictionaryType = $"Dictionary<string, {additionalPropertiesType.TypeName}>";
                    return (PropertyType.Normal, className, new PropertyDto(dictionaryType, className, null, schema.Description));
                }
            }

            var model = MapInlineModel(@interface, schema, parentName, directory, className);
            return (PropertyType.Normal, className, model);
        }

        var propertyIsNullable = schema.Nullable || Settings.SupportExtensionXNullable && schema.TryGetXNullable(out var x) && x;
        var property = MapSchema(@interface, schema, parentName, objectName, propertyIsNullable, true, openApiSpecVersion, directory);
        if (property.IsFirst)
        {
            return (PropertyType.Normal, string.Empty, property.First);
        }

        return (PropertyType.None, string.Empty, new PropertyDto("not-used", "not-used", null, "not-used"));
    }

    // Object is defined `inline`, create a new Model and use that one.
    private RestEaseModel MapInlineModel(
        RestEaseInterface @interface,
        OpenApiSchema schema,
        string parentName,
        string? directory,
        string className)
    {
        var model = @interface.ExtraModels.FirstOrDefault(m =>
            string.Equals(m.ClassName, className, StringComparison.InvariantCultureIgnoreCase));
        if (model == null)
        {
            var inlineModel = MapSchema(@interface, schema, parentName, className, false, true, null, directory);
            model = new RestEaseModel
            {
                Description = schema.Description,
                Namespace = Settings.Namespace,
                ClassName = className,
                Properties = inlineModel.Second,
                Priority = 1001
            };
            @interface.ExtraModels.Add(model);
        }

        return model;
    }

    public PropertyDto? TryMapPropertyReference(RestEaseInterface @interface, OpenApiSchema schema, string? name, string? directory)
    {
        switch (schema.Reference)
        {
            case { IsLocal: true }:
                if (@interface.OpenApiDocument.Components.Schemas.TryGetValue(schema.Reference.Id, out var internalSchema))
                {
                    if (internalSchema.AdditionalProperties == null)
                    {
                        var className = MakeValidClassName(schema.Reference.Id);
                        return new PropertyDto(className, name ?? className, null, schema.Description);
                    }

                    var local = MapSchema(
                        @interface,
                        internalSchema,
                        schema.Reference.Id,
                        null,
                        internalSchema.Nullable,
                        true,
                        OpenApiSpecVersion.OpenApi3_0, // TODO
                        directory);

                    if (local.IsFirst)
                    {
                        return local.First;
                    }

                    if (local.IsSecond && local.Second.Count == 0)
                    {
                        // "Microsoft.AspNetCore.Mvc.ProblemDetails" has "additionalProperties": { }
                        return null;
                    }
                }

                throw new InvalidOperationException();

            case { IsExternal: true }:
                var externalProperty = new ExternalReferenceMapper(Settings, @interface).MapProperty(schema.Reference, directory);
                return new PropertyDto(externalProperty.Type, name ?? externalProperty.Name, null, "not-used");

            default:
                return null;
        }
    }

    private PropertyDto MapEnumSchema(RestEaseInterface @interface, OpenApiSchema schema, string parentName, string name, string nameCamelCase, string nullable)
    {
        var enumNamePostfix = Settings.PreferredEnumType == EnumType.Enum ? "EnumType" : "Constants";

        var enumName = $"{parentName}{name}{enumNamePostfix}".ToPascalCase();
        var basename = enumName;
        var enumValues = schema.Enum.OfType<OpenApiString>()
            .SelectMany(str => str.Value.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim())).ToList();

        var existingEnums = @interface.ExtraEnums.Where(e => e.BaseName == enumName).ToList();
        if (!existingEnums.Any())
        {
            var newEnum = new RestEaseEnum
            {
                Description = schema.Description,
                Namespace = Settings.Namespace,
                BaseName = enumName,
                EnumName = enumName,
                Values = enumValues
            };

            @interface.ExtraEnums.Add(newEnum);
        }
        else
        {
            var existingEnumWithSameValues = existingEnums.SingleOrDefault(existingEnum => existingEnum.Values.SequenceEqual(enumValues));
            if (existingEnumWithSameValues == null)
            {
                int matchingCount = existingEnums.Count;

                enumName = $"{enumName}{matchingCount}";

                var newEnum = new RestEaseEnum
                {
                    Description = schema.Description,
                    Namespace = Settings.Namespace,
                    BaseName = basename,
                    EnumName = enumName,
                    Values = enumValues
                };

                @interface.ExtraEnums.Add(newEnum);
            }
            else
            {
                enumName = existingEnumWithSameValues.EnumName;
            }
        }

        var type = Settings.PreferredEnumType == EnumType.Enum ? $"{enumName}{nullable}" : "string";

        return new PropertyDto(type, nameCamelCase, null, schema.Description);
    }
}