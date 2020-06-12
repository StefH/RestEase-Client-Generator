using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Readers;
using RamlToOpenApiConverter;
using RestEaseClientGenerator.Builders;
using RestEaseClientGenerator.Mappers;
using RestEaseClientGenerator.Models;
using RestEaseClientGenerator.Models.Internal;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;

namespace RestEaseClientGenerator
{
    public class Generator : IGenerator
    {
        public ICollection<GeneratedFile> FromFile(string path, GeneratorSettings settings, out OpenApiDiagnostic diagnostic)
        {
            OpenApiDocument document;
            if (Path.GetExtension(path).EndsWith("raml", StringComparison.OrdinalIgnoreCase))
            {
                diagnostic = new OpenApiDiagnostic();
                document = new RamlConverter().ConvertToOpenApiDocument(path);
            }
            else
            {
                var reader = new OpenApiStreamReader();
                document = reader.Read(File.OpenRead(path), out diagnostic);
            }

            return FromDocument(document, settings, diagnostic.SpecificationVersion);
        }

        public ICollection<GeneratedFile> FromDocument(OpenApiDocument document, GeneratorSettings settings, OpenApiSpecVersion openApiSpecVersion = OpenApiSpecVersion.OpenApi2_0)
        {
            var schemaMapper = new SchemaMapper(settings);

            IEnumerable<RestEaseModel> models;
            if (document.Components?.Schemas != null)
            {
                models = new ModelsMapper(settings, schemaMapper, openApiSpecVersion)
                    .Map(document.Components.Schemas).ToList();
            }
            else
            {
                models = Enumerable.Empty<RestEaseModel>();
            }

            var @interface = new InterfaceMapper(settings, schemaMapper).Map(document);

            var files = new List<GeneratedFile>();

            if (settings.GenerationType.HasFlag(GenerationType.Api))
            {
                // Add Interface
                files.Add(new GeneratedFile
                {
                    Path = settings.ApiNamespace,
                    Name = $"{@interface.Name}.cs",
                    Content = new InterfaceBuilder(settings).Build(@interface, models.Any())
                });

                var extensions = new ExtensionMethodsBuilder(settings).Build(@interface, @interface.Name);
                if (extensions != null)
                {
                    // Add ApiExtension
                    files.Add(new GeneratedFile
                    {
                        Path = settings.ApiNamespace,
                        Name = $"{new string(@interface.Name.Skip(1).ToArray())}Extensions.cs",
                        Content = extensions
                    });
                }
            }

            if (settings.GenerationType.HasFlag(GenerationType.Models))
            {
                // Add Models
                var modelBuilder = new ModelBuilder(settings);
                files.AddRange(models.Select(model => new GeneratedFile
                {
                    Path = settings.ModelsNamespace,
                    Name = $"{model.ClassName}.cs",
                    Content = modelBuilder.Build(model)
                }));

                // Add Inline Models
                files.AddRange(@interface.InlineModels.Select(model => new GeneratedFile
                {
                    Path = settings.ModelsNamespace,
                    Name = $"{model.ClassName}.cs",
                    Content = modelBuilder.Build(model)
                }));

                // Add Inline Enums
                var enumBuilder = new EnumBuilder(settings);
                files.AddRange(schemaMapper.Enums.Select(@enum => new GeneratedFile
                {
                    Path = settings.ModelsNamespace,
                    Name = $"{@enum.EnumName}.cs",
                    Content = enumBuilder.Build(@enum)
                }));
            }

            if (settings.SingleFile)
            {
                return new[] { new GeneratedFile
                {
                    Path = string.Empty,
                    Name = $"{@interface.Name}.cs",
                    Content = string.Join("\r\n", files.Select(f => f.Content))
                }};
            }

            return files;
        }
    }
}