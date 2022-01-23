using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Readers;
using OpenApi.RestEase.Generator.Builders;
using OpenApi.RestEase.Generator.Mappers;
using OpenApi.RestEase.Generator.Models;
using OpenApi.RestEase.Generator.Models.Internal;
using OpenApi.RestEase.Generator.Settings;
using OpenApi.RestEase.Generator.Types;
using RamlToOpenApiConverter;

namespace OpenApi.RestEase.Generator;

public class Generator : IGenerator
{
    public ICollection<GeneratedFile> FromFile(string path, GeneratorSettings settings, out OpenApiDiagnostic diagnostic)
    {
        var directory = Path.GetDirectoryName(path);

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

        return FromDocument(document, settings, diagnostic.SpecificationVersion, directory);
    }

    public InternalDto FromFileInternal(string path, GeneratorSettings settings, out OpenApiDiagnostic diagnostic, OpenApiSpecVersion openApiSpecVersion = OpenApiSpecVersion.OpenApi2_0)
    {
        var directory = Path.GetDirectoryName(path);

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

        return FromDocumentInternal(document, settings, openApiSpecVersion, directory);
    }

    public InternalDto FromDocumentInternal(OpenApiDocument document, GeneratorSettings settings, OpenApiSpecVersion openApiSpecVersion = OpenApiSpecVersion.OpenApi2_0, string? directory = null)
    {
        var schemaMapper = new SchemaMapper(settings);

        var @interface = new InterfaceMapper(settings, schemaMapper).Map(document, directory);

        var models = new List<RestEaseModel>();
        var enums = new List<RestEaseEnum>();

        if (document.Components?.Schemas != null)
        {
            var modelsOrEnums = new ModelsMapper(@interface, settings, schemaMapper, OpenApiSpecVersion.OpenApi2_0, directory)
                    .Map(document.Components.Schemas);

            foreach (var model in modelsOrEnums)
            {
                if (model.IsFirst)
                {
                    models.Add(model.First);
                }

                if (model.IsSecond)
                {
                    enums.Add(model.Second);
                }
            }
        }

        // Add Inline/External Models
        foreach (var extraModel in @interface.ExtraModels)
        {
            models.Add(extraModel);
        }

        // Add Inline Enums
        foreach (var inlineEnum in @interface.ExtraEnums)
        {
            enums.Add(inlineEnum);
        }

        return new InternalDto(@interface, models, enums);
    }

    public ICollection<GeneratedFile> FromDocument(OpenApiDocument document, GeneratorSettings settings, OpenApiSpecVersion openApiSpecVersion = OpenApiSpecVersion.OpenApi2_0, string? directory = null)
    {
        var result = FromDocumentInternal(document, settings, openApiSpecVersion, directory);

        var files = new List<GeneratedFile>();

        var @interface = result.Interface;

        if (settings.GenerationType.HasFlag(GenerationType.Api))
        {
            var anyModels = result.Models.Any();

            // Add Interface
            files.Add(new GeneratedFile
            (
                FileType.Api,
                settings.ApiNamespace,
                $"{@interface.Name}.cs",
                @interface.Name,
                new InterfaceBuilder(settings).Build(@interface, anyModels)
            ));

            var extensionContent = new ExtensionMethodsBuilder(settings).Build(@interface, @interface.Name);
            if (extensionContent != null)
            {
                var extensionClassName = $"{@interface.Name.Substring(1)}Extensions";

                // Add ApiExtension
                files.Add(new GeneratedFile
                (
                    FileType.ApiExtensions,
                    settings.ApiNamespace,
                    $"{extensionClassName}.cs",
                    extensionClassName,
                    extensionContent
                ));
            }
        }

        if (settings.GenerationType.HasFlag(GenerationType.Models))
        {
            // Add Models + Inline/External Models
            var modelBuilder = new ModelBuilder(settings);
            var allModels = result.Models.Union(@interface.ExtraModels)
                .GroupBy(r => r.ClassName)
                .Select(r => r.First())
                .OrderBy(m => m.ClassName)
                .ToList();
            files.AddRange(allModels.Select(model => new GeneratedFile
            (
                FileType.Model,
                settings.ModelsNamespace,
                $"{model.ClassName}.cs",
                model.ClassName,
                modelBuilder.Build(model)
            )));

            // Add Inline/External Enums
            var enumBuilder = new EnumBuilder(settings);
            var extraEnums = result.Enums
                .GroupBy(r => r.EnumName)
                .SelectMany(r => r);

            files.AddRange(extraEnums.Select(@enum => new GeneratedFile
            (
                FileType.Model,
                settings.ModelsNamespace,
                $"{@enum.EnumName}.cs",
                @enum.EnumName,
                enumBuilder.Build(@enum)
            )));
        }

        if (settings.SingleFile)
        {
            var content = files
                .GroupBy(f => f.ClassOrInterface)
                .Distinct()
                .Select(f => f.First().Content);

            return new[] { new GeneratedFile
            (
                FileType.ApiAndModels,
                string.Empty,
                $"{@interface.Name}.cs",
                @interface.Name,
                string.Join("\r\n", content)
            )};
        }

        return files;
    }
}