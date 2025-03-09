using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Models.Interfaces;
using RestEaseClientGenerator.Types.Internal;

namespace RestEaseClientGenerator.Extensions;

internal static class OpenApiSchemaExtensions
{
    public static bool IsNullable(this IOpenApiSchema? schema)
    {
        return schema?.Type == JsonSchemaType.Null;
    }

    /// <summary>
    /// https://stackoverflow.com/questions/48111459/how-to-define-a-property-that-can-be-string-or-null-in-openapi-swagger
    /// </summary>
    public static bool TryGetXNullable(this IOpenApiSchema schema, out bool value)
    {
        value = false;

        if (schema.Extensions.TryGetValue("x-nullable", out var e)) // TODO && e is OpenApiBoolean openApiBoolean
        {
            value = false; // openApiBoolean.Value; TODO
            return true;
        }

        return false;
    }

    public static SchemaType GetSchemaType(this IOpenApiSchema schema)
    {
        switch (schema.Type)
        {
            case JsonSchemaType.Object:
                return SchemaType.Object;

            case JsonSchemaType.Array:
                return SchemaType.Array;

            case JsonSchemaType.Integer:
                return SchemaType.Integer;

            case JsonSchemaType.Number:
                return SchemaType.Number;

            case JsonSchemaType.Boolean:
                return SchemaType.Boolean;

            case JsonSchemaType.String:
                return SchemaType.String;

            //case "file":
            //    return SchemaType.File;

            default:
                return SchemaType.Unknown;
        }
    }

    public static SchemaFormat GetSchemaFormat(this IOpenApiSchema schema)
    {
        switch (schema.Format)
        {
            case "float":
                return SchemaFormat.Float;

            case "double":
                return SchemaFormat.Double;

            case "int32":
                return SchemaFormat.Int32;

            case "int64":
                return SchemaFormat.Int64;

            case "date":
                return SchemaFormat.Date;

            case "date-time":
                return SchemaFormat.DateTime;

            case "password":
                return SchemaFormat.Password;

            case "byte":
                return SchemaFormat.Byte;

            case "binary":
                return SchemaFormat.Binary;

            default:
                return SchemaFormat.Undefined;
        }
    }
}