using AnyOfTypes;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.Models.Internal;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;

namespace RestEaseClientGenerator.Mappers;

internal class SchemaMapper : BaseMapper
{
    public readonly IList<RestEaseEnum> Enums = new List<RestEaseEnum>();

    public SchemaMapper(GeneratorSettings settings) : base(settings)
    {
    }

    public AnyOf<PropertyDto, IList<PropertyDto>> MapSchema(RestEaseInterface @interface, OpenApiSchema schema, string? name, bool isNullable, bool pascalCase, OpenApiSpecVersion? openApiSpecVersion, string? directory)
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
                        var or = TryMapPropertyReference(@interface, schema.Items.Reference, "not-used", directory);
                        return or != null ?
                            new PropertyDto(MapArrayType(MakeValidModelName(or.Type)), nameCamelCase) :
                            new PropertyDto(MapArrayType("object"), nameCamelCase);

                    case SchemaType.String:
                        if (schema.Items.Enum != null && schema.Items.Enum.Any() && Settings.PreferredEnumType == EnumType.Enum)
                        {
                            return new PropertyDto(MapArrayType(MakeValidModelName(name)), nameCamelCase);
                        }
                        else
                        {
                            var sp = MapSchema(@interface, schema.Items, null, schema.Items.Nullable, true, openApiSpecVersion, directory);
                            return new PropertyDto(MapArrayType(sp.First.Type), nameCamelCase);
                        }

                    default:
                        var p = MapSchema(@interface, schema.Items, null, schema.Items.Nullable, true, openApiSpecVersion, directory);
                        return new PropertyDto(MapArrayType(p.First.Type), nameCamelCase);
                }

            case SchemaType.Boolean:
                return new PropertyDto($"bool{nullable}", nameCamelCase);

            case SchemaType.Integer:
                return schema.GetSchemaFormat() switch
                {
                    SchemaFormat.Int64 => new PropertyDto($"long{nullable}", nameCamelCase),
                    _ => new PropertyDto($"int{nullable}", nameCamelCase)
                };

            case SchemaType.Number:
                return schema.GetSchemaFormat() switch
                {
                    SchemaFormat.Float => new PropertyDto($"float{nullable}", nameCamelCase),
                    _ => new PropertyDto($"double{nullable}", nameCamelCase)
                };

            case SchemaType.String:
                switch (schema.GetSchemaFormat())
                {
                    case SchemaFormat.Date:
                    case SchemaFormat.DateTime:
                        return new PropertyDto($"{DateTime}{nullable}", nameCamelCase);

                    case SchemaFormat.Byte:
                    case SchemaFormat.Binary:
                        return Settings.ApplicationOctetStreamType switch
                        {
                            ApplicationOctetStreamType.Stream => new PropertyDto("System.IO.Stream", nameCamelCase),
                            _ => new PropertyDto("byte[]", nameCamelCase)
                        };

                    default:
                        if (schema.Enum != null && schema.Enum.Any())
                        {
                            return Settings.PreferredEnumType switch
                            {
                                EnumType.Enum => MapEnumSchema(schema, name, nameCamelCase, nullable),
                                EnumType.Integer => new PropertyDto("int", nameCamelCase),
                                EnumType.Object => new PropertyDto("object", nameCamelCase),
                                _ => new PropertyDto("string", nameCamelCase)
                            };
                        }

                        return new PropertyDto("string", nameCamelCase);
                }

            case SchemaType.Object:
            case SchemaType.Unknown:
                var list = new List<PropertyDto>();
                foreach (var schemaProperty in schema.Properties)
                {
                    var openApiSchema = schemaProperty.Value;
                    var objectName = pascalCase ? schemaProperty.Key.ToPascalCase() : schemaProperty.Key;

                    var propertyDto = MapProperty(@interface, openApiSpecVersion, openApiSchema, objectName, directory);
                    if (propertyDto.type == PropertyType.Normal)
                    {
                        if (propertyDto.p.IsFirst)
                        {
                            list.Add(propertyDto.p.First);
                        }
                        else
                        {
                            list.Add(new PropertyDto(objectName, objectName));
                            // list.AddRange(propertyDto.p.Second);
                        }
                    }
                    else if (propertyDto.type == PropertyType.Reference)
                    {
                        list.Add(propertyDto.p.First);
                    }
                }

                foreach (var allOrAny in schema.AllOf.Union(schema.AnyOf))
                {
                    var extendsType = MapProperty(@interface, openApiSpecVersion, allOrAny, name, directory);
                    if (extendsType.type == PropertyType.Reference)
                    {
                        list.Add(new PropertyDto("not-used", "not-used", extendsType.p.First.Type));
                    }
                    else if (extendsType.type == PropertyType.Normal)
                    {
                        if (extendsType.p.IsFirst)
                        {
                            list.Add(extendsType.p.First);
                        }
                        else
                        {
                            list.AddRange(extendsType.p.Second);
                        }
                    }
                }

                return list;

            case SchemaType.File:
                return Settings.MultipartFormDataFileType switch
                {
                    MultipartFormDataFileType.Stream => new PropertyDto("System.IO.Stream", nameCamelCase),
                    _ => new PropertyDto("byte[]", nameCamelCase)
                };

            default:
                throw new InvalidOperationException();
        }
    }

    private (PropertyType type, AnyOf<PropertyDto, IList<PropertyDto>> p) MapProperty(
        RestEaseInterface @interface,
        OpenApiSpecVersion? openApiSpecVersion,
        OpenApiSchema openApiSchema,
        string objectName,
        string? directory)
    {
        if (new[] { SchemaType.Object, SchemaType.Unknown }.Contains(openApiSchema.GetSchemaType()))
        {
            //if (openApiSchema.AdditionalProperties?.Reference?.Id != null)
            //{
            //    var dictionaryType = $"Dictionary<string, {MakeValidReferenceId(openApiSchema.AdditionalProperties.Reference.Id)}>";
            //    return new PropertyDto(dictionaryType, objectName);
            //}

            var e = TryMapPropertyReference(@interface, openApiSchema.Reference, objectName, directory);
            if (e is not null)
            {
                return (PropertyType.Reference, e);
            }

            // Object is defined `inline`, create a new Model and use that one.
            var existingModel = @interface.ExtraModels.FirstOrDefault(m => m.ClassName == objectName);
            AnyOf<PropertyDto, IList<PropertyDto>> x2;
            if (existingModel == null)
            {
                var inlineModel = MapSchema(@interface, openApiSchema, null, false, true, null, directory);
                //if (inlineModel.IsSecond)
                {
                    var newModel = new RestEaseModel
                    {
                        Namespace = Settings.Namespace,
                        ClassName = objectName,
                        Properties = inlineModel.Second
                    };
                    @interface.ExtraModels.Add(newModel);

                    x2 = inlineModel;
                }
            }
            else
            {
                x2 = existingModel.Properties.ToList();
            }

            return (PropertyType.Normal, x2);
        }

        var propertyIsNullable = openApiSchema.Nullable || Settings.SupportExtensionXNullable && openApiSchema.TryGetXNullable(out var x) && x;
        var property = MapSchema(@interface, openApiSchema, objectName, propertyIsNullable, true, openApiSpecVersion, directory);
        if (property.IsFirst)
        {
            return (PropertyType.Normal, property.First);
        }
        else
        {
            return (PropertyType.None, new PropertyDto("x", "y"));
        }

        //return null;
    }

    public PropertyDto? TryMapPropertyReference(RestEaseInterface @interface, OpenApiReference? reference, string? name, string? directory)
    {
        switch (reference)
        {
            case { IsLocal: true }:
                var className = MakeValidReferenceId(reference.Id);
                //var existingModel = @interface.ExtraModels.FirstOrDefault(m => m.ClassName == className);
                //if (existingModel == null)
                //{
                //    var extraModel = MapSchema(@interface, openApiSchema, className, false, true, null, directory);
                //    var newModel = new RestEaseModel
                //    {
                //        Namespace = Settings.Namespace,
                //        ClassName = className,
                //        Properties = extraModel.Second
                //    };
                //    @interface.ExtraModels.Add(newModel);
                //}
                return new PropertyDto(className, name ?? className);

            case { IsExternal: true }:
                var externalModel = new ExternalReferenceMapper(Settings, @interface).MapProperty(reference, directory);
                return new PropertyDto(externalModel.Type, name ?? externalModel.Name); // TODO

            default:
                return null; // TODO : throw?
        }
    }

    private PropertyDto MapEnumSchema(OpenApiSchema schema, string name, string nameCamelCase, string nullable)
    {
        string enumName = name.ToPascalCase();
        string basename = enumName;
        var enumValues = schema.Enum.OfType<OpenApiString>()
            .SelectMany(str => str.Value.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim())).ToList();

        var existingEnums = Enums.Where(e => e.BaseName == enumName).ToList();
        if (!existingEnums.Any())
        {
            var newEnum = new RestEaseEnum
            {
                Namespace = Settings.Namespace,
                BaseName = enumName,
                EnumName = enumName,
                Values = enumValues,
                EnumType = EnumType.Enum
            };

            Enums.Add(newEnum);
        }
        else
        {
            var existingEnumWithSameValues = existingEnums
                .SingleOrDefault(existingEnum => (existingEnum.Values ?? new List<string>()).SequenceEqual(enumValues));

            if (existingEnumWithSameValues == null)
            {
                int matchingCount = existingEnums.Count;

                enumName = $"{enumName}{matchingCount}";

                var newEnum = new RestEaseEnum
                {
                    Namespace = Settings.Namespace,
                    BaseName = basename,
                    EnumName = enumName,
                    Values = enumValues,
                    EnumType = EnumType.Enum
                };

                Enums.Add(newEnum);
            }
            else
            {
                enumName = existingEnumWithSameValues.EnumName;
            }
        }

        return new PropertyDto($"{enumName}{nullable}", nameCamelCase);
    }
}