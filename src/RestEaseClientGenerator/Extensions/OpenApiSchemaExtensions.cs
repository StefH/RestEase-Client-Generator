using Microsoft.OpenApi.Models;
using RestEaseClientGenerator.Types;

namespace RestEaseClientGenerator.Extensions
{
    public static class OpenApiSchemaExtensions
    {
        public static SchemaType GetSchemaType(this OpenApiSchema schema)
        {
            switch (schema?.Type)
            {
                case "object":
                    return SchemaType.Object;

                case "array":
                    return SchemaType.Array;

                case "integer":
                    return SchemaType.Integer;

                case "number":
                    return SchemaType.Number;

                case "boolean":
                    return SchemaType.Boolean;

                case "string":
                    return SchemaType.String;

                default:
                    return SchemaType.Unknown;
            }
        }

        public static SchemaFormat GetSchemaFormat(this OpenApiSchema schema)
        {
            switch (schema?.Type)
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

                default:
                    return SchemaFormat.Undefined;
            }
        }
    }
}