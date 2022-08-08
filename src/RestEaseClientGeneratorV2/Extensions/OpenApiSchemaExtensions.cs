using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;
using RestEaseClientGenerator.Types.Internal;

namespace RestEaseClientGenerator.Extensions;

internal static class OpenApiSchemaExtensions
{
    /// <summary>
    /// https://stackoverflow.com/questions/48111459/how-to-define-a-property-that-can-be-string-or-null-in-openapi-swagger
    /// </summary>
    public static bool TryGetXNullable(this OpenApiSchema schema, out bool value)
    {
        value = false;

        if (schema.Extensions.TryGetValue("x-nullable", out IOpenApiExtension e) && e is OpenApiBoolean openApiBoolean)
        {
            value = openApiBoolean.Value;
            return true;
        }

        return false;
    }

    /// <summary>
    /// Check if this schema does not have any properties or AdditionalProperties, so it's just a an object.
    /// </summary>
    public static bool IsJustAnObject(this OpenApiSchema schema)
    {
        return !schema.AnyOf.Any() && !schema.AllOf.Any() && !schema.Properties.Any() && schema.AdditionalProperties == null;
    }

    public static IReadOnlyList<OpenApiSchema> GetAllOfAndAnyOf(this OpenApiSchema schema)
    {
        return schema.AllOf.Union(schema.AnyOf).ToList();
    }

    public static SchemaType GetSchemaType(this OpenApiSchema schema)
    {
        return schema.Type switch
        {
            "object" => SchemaType.Object,
            "array" => SchemaType.Array,
            "integer" => SchemaType.Integer,
            "number" => SchemaType.Number,
            "boolean" => SchemaType.Boolean,
            "string" => SchemaType.String,
            "file" => SchemaType.File,
            _ => SchemaType.Unknown
        };
    }

    public static SchemaFormat GetSchemaFormat(this OpenApiSchema schema)
    {
        return schema.Format switch
        {
            "float" => SchemaFormat.Float,
            "double" => SchemaFormat.Double,
            "int32" => SchemaFormat.Int32,
            "int64" => SchemaFormat.Int64,
            "date" => SchemaFormat.Date,
            "date-time" => SchemaFormat.DateTime,
            "password" => SchemaFormat.Password,
            "byte" => SchemaFormat.Byte,
            "binary" => SchemaFormat.Binary,
            _ => SchemaFormat.Undefined
        };
    }

    //public static SchemaType GetCSharpType(this OpenApiSchema schema)
    //{
    //    return schema.Type switch
    //    {
    //        "object" => SchemaType.Object,
    //        "array" => SchemaType.Array,
    //        "integer" => SchemaType.Integer,
    //        "number" => SchemaType.Number,
    //        "boolean" => SchemaType.Boolean,
    //        "string" => SchemaType.String,
    //        "file" => SchemaType.File,
    //        _ => SchemaType.Unknown
    //    };
    //}
}