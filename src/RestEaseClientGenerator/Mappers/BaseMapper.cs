using System.Collections.Generic;
using Microsoft.OpenApi.Models;
using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;
using RestEaseClientGenerator.Utils;

namespace RestEaseClientGenerator.Mappers
{
    public abstract class BaseMapper
    {
        private string DateTime => Settings.UseDateTimeOffset ? "DateTimeOffset" : "DateTime";

        protected readonly GeneratorSettings Settings;

        protected BaseMapper(GeneratorSettings settings)
        {
            Settings = settings;
        }

        protected string MapArrayType(object value)
        {
            switch (Settings.ArrayType)
            {
                case ArrayType.IEnumerable:
                    return $"IEnumerable<{value}>";

                case ArrayType.ICollection:
                    return $"ICollection<{value}>";

                case ArrayType.IList:
                    return $"IList<{value}>";

                case ArrayType.List:
                    return $"List<{value}>";

                default:
                    return $"{value}[]";
            }
        }

        protected object MapSchema(OpenApiSchema schema, string name, bool isNullable, bool pascalCase = true)
        {
            if (schema == null)
            {
                return null;
            }

            string nameCamelCase = string.IsNullOrEmpty(name) ? string.Empty : $" {(pascalCase ? name.ToPascalCase() : name)}";
            string nullable = isNullable ? "?" : string.Empty;

            switch (schema.GetSchemaType())
            {
                case SchemaType.Array:
                    switch (schema.Items.GetSchemaType())
                    {
                        case SchemaType.Object:
                            return schema.Items.Reference != null ?
                                $"{MapArrayType(CSharpUtils.CreateValidIdentifier(schema.Items.Reference.Id))}{nameCamelCase}" :
                                $"{MapArrayType("object")}{nameCamelCase}";

                        case SchemaType.Unknown:
                            return $"{MapArrayType("object")}{nameCamelCase}";

                        default:
                            return $"{MapArrayType(MapSchema(schema.Items, null, schema.Items.Nullable))}{nameCamelCase}";
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
                            string objectType = openApiSchema.Reference != null ? CSharpUtils.CreateValidIdentifier(openApiSchema.Reference.Id.Replace(" ", ""), CasingType.Pascal) : "object";

                            list.Add($"{objectType} {objectName}");
                        }
                        else
                        {
                            var property = MapSchema(openApiSchema, schemaProperty.Key, openApiSchema.Nullable);
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
    }
}