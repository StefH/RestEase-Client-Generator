using AnyOfTypes;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.Models.Internal;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;
using RestEaseClientGenerator.Types.Internal;

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
                switch (schema.Items.GetSchemaType())
                {
                    case SchemaType.Object:
                    case SchemaType.Unknown:
                        var or = TryMapPropertyReference(@interface, schema.Items, "not-used", directory);
                        return or != null ?
                            new PropertyDto(MapArrayType(MakeValidClassName(or.Type)), nameCamelCase, schema.Description) :
                            new PropertyDto(MapArrayType("object"), nameCamelCase, schema.Description);

                    case SchemaType.String:
                        if (schema.Items.Enum != null && schema.Items.Enum.Any() && Settings.PreferredEnumType == EnumType.Enum)
                        {
                            return new PropertyDto(MapArrayType(MakeValidClassName(name)), nameCamelCase, schema.Description);
                        }
                        else
                        {
                            var sp = MapSchema(@interface, schema.Items, parentName, null, schema.Items.Nullable, true, openApiSpecVersion, directory);
                            return new PropertyDto(MapArrayType(sp.First.Type), nameCamelCase, schema.Description);
                        }

                    default:
                        var p = MapSchema(@interface, schema.Items, parentName, null, schema.Items.Nullable, true, openApiSpecVersion, directory);
                        return new PropertyDto(MapArrayType(p.First.Type), nameCamelCase, schema.Description);
                }

            case SchemaType.Boolean:
                return new PropertyDto($"bool{nullable}", nameCamelCase, schema.Description);

            case SchemaType.Integer:
                return schema.GetSchemaFormat() switch
                {
                    SchemaFormat.Int64 => new PropertyDto($"long{nullable}", nameCamelCase, schema.Description),
                    _ => new PropertyDto($"int{nullable}", nameCamelCase, schema.Description)
                };

            case SchemaType.Number:
                return schema.GetSchemaFormat() switch
                {
                    SchemaFormat.Float => new PropertyDto($"float{nullable}", nameCamelCase, schema.Description),
                    _ => new PropertyDto($"double{nullable}", nameCamelCase, schema.Description)
                };

            case SchemaType.String:
                switch (schema.GetSchemaFormat())
                {
                    case SchemaFormat.Date:
                    case SchemaFormat.DateTime:
                        return new PropertyDto($"{DateTime}{nullable}", nameCamelCase, schema.Description);

                    case SchemaFormat.Byte:
                    case SchemaFormat.Binary:
                        return Settings.ApplicationOctetStreamType switch
                        {
                            ApplicationOctetStreamType.Stream => new PropertyDto("System.IO.Stream", nameCamelCase, schema.Description),
                            _ => new PropertyDto("byte[]", nameCamelCase, schema.Description)
                        };

                    default:
                        if (schema.Enum != null && schema.Enum.Any())
                        {
                            return MapEnumSchema(@interface, schema, parentName, name, nameCamelCase, nullable);
                        }

                        return new PropertyDto("string", nameCamelCase, schema.Description);
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
                        return new PropertyDto(dictionaryType, string.Empty, schema.Description);
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
                            list.Add(new PropertyDto(property.Result.First.Type, property.Result.First.Name, openApiSchema.Description));
                            break;

                        case PropertyType.Normal:
                            list.Add(new PropertyDto(property.className, objectName, openApiSchema.Description));
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
                            list.Add(new PropertyDto("not-used", "not-used", allOrAny.Description, property.Result.First.Type));
                            break;

                        case PropertyType.Normal when property.Result.IsFirst:
                            list.Add(property.Result.First);
                            break;

                        case PropertyType.Normal:
                            list.AddRange(property.Result.Second);
                            break;
                    }
                }

                return list;

            case SchemaType.File:
                return Settings.MultipartFormDataFileType switch
                {
                    MultipartFormDataFileType.Stream => new PropertyDto("System.IO.Stream", nameCamelCase, schema.Description),
                    _ => new PropertyDto("byte[]", nameCamelCase, schema.Description)
                };

            default:
                throw new InvalidOperationException();
        }
    }

    private (PropertyType Type, string className, AnyOf<PropertyDto, IList<PropertyDto>> Result) TryMapProperty(
        RestEaseInterface @interface,
        OpenApiSpecVersion? openApiSpecVersion,
        OpenApiSchema schemaIn,
        string parentName,
        string objectName,
        string? directory)
    {
        if (new[] { SchemaType.Object, SchemaType.Unknown }.Contains(schemaIn.GetSchemaType()))
        {
            var referencedProperty = TryMapPropertyReference(@interface, schemaIn, objectName, directory);
            if (referencedProperty is not null)
            {
                return (PropertyType.Reference, string.Empty, referencedProperty);
            }

            var className = MakeValidClassName($"{parentName}{objectName}");

            if (schemaIn.AdditionalProperties != null)
            {
                var additionalPropertiesType = TryMapProperty(@interface, openApiSpecVersion, schemaIn.AdditionalProperties, parentName, objectName, directory);
                if (additionalPropertiesType.Result.IsFirst)
                {
                    var dictionaryType = $"Dictionary<string, {additionalPropertiesType.Result.First.Type}>";
                    return (PropertyType.Normal, objectName, new PropertyDto(dictionaryType, objectName));
                }
                else
                {
                    var dictionaryType = $"Dictionary<string, {additionalPropertiesType.className}>";
                    return (PropertyType.Normal, className, new PropertyDto(dictionaryType, className));
                }
            }

            // Object is defined `inline`, create a new Model and use that one.
            var model = @interface.ExtraModels.FirstOrDefault(m => string.Equals(m.ClassName, className, StringComparison.InvariantCultureIgnoreCase));
            if (model == null)
            {
                var inlineModel = MapSchema(@interface, schemaIn, parentName, className, false, true, null, directory);
                model = new RestEaseModel
                {
                    Description = schemaIn.Description,
                    Namespace = Settings.Namespace,
                    ClassName = className,
                    Properties = inlineModel.Second,
                    Priority = 1001
                };
                @interface.ExtraModels.Add(model);

                return (PropertyType.Normal, className, inlineModel);
            }

            return (PropertyType.Normal, className, model.Properties.ToList());
        }

        var propertyIsNullable = schemaIn.Nullable || Settings.SupportExtensionXNullable && schemaIn.TryGetXNullable(out var x) && x;
        var property = MapSchema(@interface, schemaIn, parentName, objectName, propertyIsNullable, true, openApiSpecVersion, directory);
        if (property.IsFirst)
        {
            return (PropertyType.Normal, string.Empty, property.First);
        }

        return (PropertyType.None, string.Empty, new PropertyDto("not-used", "not-used", "not-used"));
    }

    public PropertyDto? TryMapPropertyReference(RestEaseInterface @interface, OpenApiSchema schema, string? name, string? directory)
    {
        switch (schema.Reference)
        {
            case { IsLocal: true }:
                var className = MakeValidReferenceId(schema.Reference.Id);
                return new PropertyDto(className, name ?? className, schema.Description);

            case { IsExternal: true }:
                var externalProperty = new ExternalReferenceMapper(Settings, @interface).MapProperty(schema.Reference, directory);
                return new PropertyDto(externalProperty.Type, name ?? externalProperty.Name, "not-used");

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

        return new PropertyDto(type, nameCamelCase, schema.Description);
    }
}