using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.OpenApi.Readers;
using RestEaseClientGenerator.Builders;
using RestEaseClientGenerator.Mappers;
using RestEaseClientGenerator.Models;
using RestEaseClientGenerator.Settings;

namespace RestEaseClientGenerator
{
    public class Generator : IGenerator
    {
        public ICollection<GeneratedFile> FromStream(Stream stream, string clientNamespace, string apiName, out OpenApiDiagnostic diagnostic)
        {
            return FromStream(stream, new GeneratorSettings
            {
                Namespace = clientNamespace,
                ApiName = apiName
            }, out diagnostic);
        }

        public ICollection<GeneratedFile> FromStream(Stream stream, GeneratorSettings settings, out OpenApiDiagnostic diagnostic)
        {
            var reader = new OpenApiStreamReader();
            var openApiDocument = reader.Read(stream, out diagnostic);

            var models = new ModelsMapper(settings).Map(openApiDocument.Components.Schemas).ToList();
            var @interface = new InterfaceMapper(settings).Map(openApiDocument);

            var files = new List<GeneratedFile>
            {
                // Add Interface
                new GeneratedFile
                {
                    Path = settings.ApiNamespace,
                    Name = $"{@interface.Name}.cs",
                    Content = new InterfaceBuilder(settings).Build(@interface, models.Any())
                }
            };

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