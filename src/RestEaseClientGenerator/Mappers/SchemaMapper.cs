using System.Security.AccessControl;
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

    public AnyOf<string, List<string>> MapSchema(RestEaseInterface @interface, OpenApiSchema schema, string? name, bool isNullable, bool pascalCase, OpenApiSpecVersion? openApiSpecVersion, string? directory)
    {
        if (schema == null)
        {
            throw new ArgumentNullException();
        }

        name ??= string.Empty;

        string nameCamelCase = string.IsNullOrEmpty(name) ? string.Empty : $" {(pascalCase ? name.ToPascalCase() : name)}";

        bool nullableForOpenApi20 = openApiSpecVersion == OpenApiSpecVersion.OpenApi2_0 && Settings.GeneratePrimitivePropertiesAsNullableForOpenApi20;
        string nullable = nullableForOpenApi20 || isNullable ? "?" : string.Empty;

        switch (schema.GetSchemaType())
        {
            case SchemaType.Array:
                switch (schema.Items.GetSchemaType())
                {
                    case SchemaType.Object:
                        return schema.Items.Reference != null ?
                            $"{MapArrayType(MakeValidModelName(schema.Items.Reference.Id))}{nameCamelCase}" :
                            $"{MapArrayType("object")}{nameCamelCase}";

                    case SchemaType.Unknown:
                        return $"{MapArrayType("object")}{nameCamelCase}";

                    case SchemaType.String:
                        if (schema.Items.Enum != null && schema.Items.Enum.Any() && Settings.PreferredEnumType == EnumType.Enum)
                        {
                            return $"{MapArrayType(MakeValidModelName(name))}{nameCamelCase}";
                        }
                        else
                        {
                            return $"{MapArrayType(MapSchema(@interface, schema.Items, null, schema.Items.Nullable, true, openApiSpecVersion, directory))}{nameCamelCase}";
                        }

                    default:
                        return $"{MapArrayType(MapSchema(@interface, schema.Items, null, schema.Items.Nullable, true, openApiSpecVersion, directory))}{nameCamelCase}";
                }

            case SchemaType.Boolean:
                return $"bool{nullable}{nameCamelCase}";

            case SchemaType.Integer:
                switch (schema.GetSchemaFormat())
                {
                    case SchemaFormat.Int64:
                        return $"long{nullable}{nameCamelCase}";

                    default:
                        return $"int{nullable}{nameCamelCase}";
                }

            case SchemaType.Number:
                switch (schema.GetSchemaFormat())
                {
                    case SchemaFormat.Float:
                        return $"float{nullable}{nameCamelCase}";

                    default:
                        return $"double{nullable}{nameCamelCase}";
                }

            case SchemaType.String:
                switch (schema.GetSchemaFormat())
                {
                    case SchemaFormat.Date:
                    case SchemaFormat.DateTime:
                        return $"{DateTime}{nullable}{nameCamelCase}";

                    case SchemaFormat.Byte:
                    case SchemaFormat.Binary:
                        return Settings.ApplicationOctetStreamType switch
                        {
                            ApplicationOctetStreamType.Stream => $"System.IO.Stream{nameCamelCase}",
                            _ => $"byte[]{nameCamelCase}"
                        };

                    default:
                        if (schema.Enum != null && schema.Enum.Any())
                        {
                            return Settings.PreferredEnumType switch
                            {
                                EnumType.Enum => MapEnumSchema(schema, name, nameCamelCase, nullable),
                                EnumType.Integer => $"int{nullable}{nameCamelCase}",
                                EnumType.Object => $"object{nameCamelCase}",
                                _ => $"string{nameCamelCase}"
                            };
                        }

                        return $"string{nameCamelCase}";
                }

            case SchemaType.Object:
            case SchemaType.Unknown:
                var list = new List<string>();
                if (schema.Properties == null)
                {
                    return list;
                }

                foreach (var schemaProperty in schema.Properties)
                {
                    var openApiSchema = schemaProperty.Value;
                    string objectName = pascalCase ? schemaProperty.Key.ToPascalCase() : schemaProperty.Key;

                    var pp = MapReference(@interface, openApiSpecVersion, openApiSchema, objectName, directory);
                    if (pp != null)
                    {
                        list.Add(pp);
                    }
                }

                foreach (var allOrAny in schema.AllOf.Union(schema.AnyOf))
                {
                    var extendsClass = MapReference(@interface, openApiSpecVersion, allOrAny, string.Empty, directory);


                }
                

                return list;

            case SchemaType.File:
                return Settings.MultipartFormDataFileType switch
                {
                    MultipartFormDataFileType.Stream => $"System.IO.Stream{nameCamelCase}",
                    _ => $"byte[]{nameCamelCase}"
                };

            default:
                throw new InvalidOperationException(); // TODO
                //return null;
        }
    }

    private string? MapReference(
        RestEaseInterface @interface,
        OpenApiSpecVersion? openApiSpecVersion,
        OpenApiSchema openApiSchema,
        string objectName,
        string? directory)
    {
        if (new[] { SchemaType.Object, SchemaType.Unknown }.Contains(openApiSchema.GetSchemaType()))
        {
            if (openApiSchema.AdditionalProperties?.Reference?.Id != null)
            {
                var dictionaryType = $"Dictionary<string, {MakeValidModelName(openApiSchema.AdditionalProperties.Reference.Id)}>";
                return $"{dictionaryType} {objectName}";
            }

            if (openApiSchema.Reference != null)
            {
                if (openApiSchema.Reference.IsLocal)
                {
                    var className = MakeValidModelName(openApiSchema.Reference.Id);
                    var existingModel = @interface.ExtraModels.FirstOrDefault(m => m.ClassName == className);
                    if (existingModel == null)
                    {
                        var extraModel = MapSchema(@interface, openApiSchema, className, false, true, null, directory);
                        var newModel = new RestEaseModel
                        {
                            Namespace = Settings.Namespace,
                            ClassName = className,
                            Properties = extraModel.Second
                        };
                        @interface.ExtraModels.Add(newModel);
                    }

                    return $"{className} {objectName}";
                }

                if (openApiSchema.Reference.IsExternal)
                {
                    var ex = new ExternalModelMapper(Settings, @interface).Map(openApiSchema, directory);

                    return $"{ex} {objectName}";
                }
            }
        }
        else
        {
            var propertyIsNullable = openApiSchema.Nullable || Settings.SupportExtensionXNullable && openApiSchema.TryGetXNullable(out var x) && x;
            var property = MapSchema(@interface, openApiSchema, objectName, propertyIsNullable, true, openApiSpecVersion, directory);
            if (property.IsFirst)
            {
                return property.First;
            }
        }

        return null;
    }

    private string MapEnumSchema(OpenApiSchema schema, string name, string nameCamelCase, string nullable)
    {
        string enumName = name.ToPascalCase();
        string basename = enumName;
        var enumValues = schema.Enum.OfType<OpenApiString>().SelectMany(str =>
            str.Value.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim())).ToList();

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
            var existingEnumWithSameValues = existingEnums.SingleOrDefault(existingEnum => existingEnum.Values.SequenceEqual(enumValues));

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

        return $"{enumName}{nullable}{nameCamelCase}";
    }
}