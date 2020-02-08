using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.Models.Internal;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;

namespace RestEaseClientGenerator.Mappers
{
    internal class SchemaMapper : BaseMapper
    {
        public readonly IList<RestEaseEnum> Enums = new List<RestEaseEnum>();

        public SchemaMapper(GeneratorSettings settings) : base(settings)
        {
        }

        public object MapSchema(OpenApiSchema schema, string name, bool isNullable, bool pascalCase, OpenApiSpecVersion? openApiSpecVersion)
        {
            if (schema == null)
            {
                return null;
            }

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
                                return $"{MapArrayType(MapSchema(schema.Items, null, schema.Items.Nullable, true, openApiSpecVersion))}{nameCamelCase}";
                            }

                        default:
                            return $"{MapArrayType(MapSchema(schema.Items, null, schema.Items.Nullable, true, openApiSpecVersion))}{nameCamelCase}";
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
                            switch (Settings.ApplicationOctetStreamType)
                            {
                                case ApplicationOctetStreamType.Stream:
                                    return $"System.IO.Stream{nameCamelCase}";

                                default:
                                    return $"byte[]{nameCamelCase}";
                            }

                        default:
                            if (schema.Enum != null && schema.Enum.Any())
                            {
                                switch (Settings.PreferredEnumType)
                                {
                                    case EnumType.Enum:
                                        return MapEnumSchema(schema, name, nameCamelCase, nullable);

                                    case EnumType.Integer:
                                        return $"int{nullable}{nameCamelCase}";

                                    case EnumType.Object:
                                        return $"object{nameCamelCase}";

                                    default:
                                        return $"string{nameCamelCase}";
                                }

                            }

                            return $"string{nameCamelCase}";
                    }

                case SchemaType.Object:
                    var list = new List<string>();

                    foreach (var schemaProperty in schema.Properties)
                    {
                        var openApiSchema = schemaProperty.Value;
                        if (openApiSchema.GetSchemaType() == SchemaType.Object)
                        {
                            string objectName = pascalCase ? schemaProperty.Key.ToPascalCase() : schemaProperty.Key;
                            string objectType = "object";

                            if (openApiSchema.AdditionalProperties?.Reference?.Id != null)
                            {
                                objectType = $"Dictionary<string, {MakeValidModelName(openApiSchema.AdditionalProperties.Reference.Id)}>";
                            }
                            else if (openApiSchema.Reference != null)
                            {
                                objectType = MakeValidModelName(openApiSchema.Reference.Id);
                            }

                            list.Add($"{objectType} {objectName}");
                        }
                        else
                        {
                            bool propertyIsNullable = openApiSchema.Nullable ||
                                                       Settings.SupportExtensionXNullable && openApiSchema.TryGetXNullable(out bool x) && x;
                            var property = MapSchema(openApiSchema, schemaProperty.Key, propertyIsNullable, true, openApiSpecVersion);
                            if (property != null && property is string propertyAsString)
                            {
                                list.Add(propertyAsString);
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
                    return null;
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
}