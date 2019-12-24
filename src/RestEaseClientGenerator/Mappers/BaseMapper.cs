using System.Collections.Generic;
using Microsoft.OpenApi.Models;
using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;

namespace RestEaseClientGenerator.Mappers
{
    public abstract class BaseMapper
    {
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

        protected string DateTime => Settings.UseDateTimeOffset ? "DateTimeOffset" : "DateTime";

        protected object MapSchema(OpenApiSchema schema, string name, bool isNullable, bool pascalCase = true)
        {
            if (schema == null)
            {
                return null;
            }

            string nameCamelCase = string.IsNullOrEmpty(name) ? "" : $" {(pascalCase ? name.ToPascalCase() : name)}";
            string nullable = isNullable ? "?" : string.Empty;

            switch (schema.GetSchemaType())
            {
                case SchemaType.Array:
                    switch (schema.Items.GetSchemaType())
                    {
                        case SchemaType.Object:
                            return schema.Items.Reference != null ?
                                $"{MapArrayType(schema.Items.Reference.Id)}{nameCamelCase}" :
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
                            return $"{MapArrayType("byte")}{nullable}{nameCamelCase}";

                        case SchemaFormat.Binary:
                            return $"object{nameCamelCase}";

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
                            string objectType = openApiSchema.Reference != null ? openApiSchema.Reference.Id.ToPascalCase().Replace(" ", "") : "object";

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

                default:
                    return null;
            }
        }
    }
}