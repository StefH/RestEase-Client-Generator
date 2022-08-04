using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Readers.Interface;
using Microsoft.OpenApi.Readers;
using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.Types.Internal;

namespace RestEaseClientGeneratorV2;

public class GeneratorV2
{
    public void X(string path)
    {
        var reader = new OpenApiStreamReader();
        var document = reader.Read(File.OpenRead(path), out var diagnostic);

        var schemas = document.Components.Schemas.OrderBy(s => s.Key).ToList();

        foreach (var schema in schemas)
        {
            MapSchema(schema.Key, schema.Value);
        }
        int y = 9;
    }

    private static void MapSchema(string key, OpenApiSchema schema)
    {
        switch (schema.GetSchemaType())
        {
            case SchemaType.Unknown:
                break;

            case SchemaType.Object:
                MapSchemaObject(key, schema);
                break;

            case SchemaType.Array:
                break;

            case SchemaType.String:
                break;

            case SchemaType.Integer:
                break;

            case SchemaType.Number:
                break;

            case SchemaType.Boolean:
                break;

            case SchemaType.File:
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private static void MapSchemaObject(string key, OpenApiSchema schema)
    {
        foreach (var schemaProperty in schema.Properties)
        {
            MapSchema(schemaProperty.Key, schemaProperty.Value);
        }
    }
}