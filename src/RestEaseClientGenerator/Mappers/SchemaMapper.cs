using System.IO;
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

    public AnyOf<string, List<string>> MapSchema(RestEaseInterface @interface, OpenApiSchema? schema, string? name, bool isNullable, bool pascalCase, OpenApiSpecVersion? openApiSpecVersion, string? directory)
    {
        if (name == "Sku")
        {
            int cccc = 9;
        }

        if (name == "SkuName")
        {
            int cccc2 = 9;
        }

        if (name == "PrivateEndpointConnectionProperties")
        {
            int x = 8;
        }

        if (name == "PrivateEndpointConnection")
        {
            int x2 = 8;
        }

        if (schema == null)
        {
            throw new ArgumentNullException();
            // return null;
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
                    if (schemaProperty.Key.ToLowerInvariant().Contains("sku"))
                    {
                        int y = 9;
                    }

                    var openApiSchema = schemaProperty.Value;
                    if (new [] { SchemaType.Object, SchemaType.Unknown }.Contains(openApiSchema.GetSchemaType()))
                    {
                        string objectName = pascalCase ? schemaProperty.Key.ToPascalCase() : schemaProperty.Key;
                        //string objectType = "object";

                        if (openApiSchema.AdditionalProperties?.Reference?.Id != null)
                        {
                            var dictionaryType = $"Dictionary<string, {MakeValidModelName(openApiSchema.AdditionalProperties.Reference.Id)}>";
                            list.Add($"{dictionaryType} {objectName}");
                        }
                        else if (openApiSchema.Reference != null)
                        {
                            if (openApiSchema.Reference.IsLocal)
                            {
                                var className = openApiSchema.Reference.Id;
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

                                list.Add($"{className} {objectName}");

                               
                                //else
                                //{
                                //    list.Add($"{mapped.First} {objectName}");
                                //}
                               

                                //return className;

                                //var s = MapSchema(@interface, openApiSchema, openApiSchema.Reference.Id, openApiSchema.Nullable, true, openApiSpecVersion, directory);
                                //if (s.IsFirst)
                                //{
                                //    list.Add($"{s.First} {objectName}");
                                //}
                                //else if (s.IsSecond)
                                //{
                                //    list.Add($"{openApiSchema.Reference.Id} {objectName}");
                                //    //list.AddRange(s.Second);

                                //    //foreach (var second in s.Second)
                                //    //{
                                //    //    int ssss = 9;
                                //    //}
                                //    //throw new InvalidOperationException();
                                //}

                                //objectType = MakeValidModelName(openApiSchema.Reference.Id);
                            }
                            else if (openApiSchema.Reference.IsExternal)
                            {
                                return new ExternalModelMapper(Settings, @interface).Map(openApiSchema, directory);
                            }
                        }
                    }
                    else
                    {
                        bool propertyIsNullable = openApiSchema.Nullable ||
                                                  Settings.SupportExtensionXNullable && openApiSchema.TryGetXNullable(out bool x) && x;
                        var property = MapSchema(@interface, openApiSchema, schemaProperty.Key, propertyIsNullable, true, openApiSpecVersion, directory);
                        if (property.IsFirst)
                        {
                            list.Add(property.First);
                        }
                    }
                }

                return list;

            case SchemaType.File:
                switch (Settings.MultipartFormDataFileType)
                {
                    case MultipartFormDataFileType.Stream:
                        return $"System.IO.Stream{nameCamelCase}";

                    default:
                        return $"byte[]{nameCamelCase}";
                }

            default:
                throw new InvalidOperationException(); // TODO
                //return null;
        }
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
                Values = enumValues
            };

            Enums.Add(newEnum);
        }
        else
        {
            var existingEnumWithSameValues = existingEnums
                .SingleOrDefault(existingEnum => existingEnum.Values.SequenceEqual(enumValues));
                
            if (existingEnumWithSameValues == null)
            {
                int matchingCount = existingEnums.Count;

                enumName = $"{enumName}{matchingCount}";

                var newEnum = new RestEaseEnum
                {
                    Namespace = Settings.Namespace,
                    BaseName = basename,
                    EnumName = enumName,
                    Values = enumValues
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