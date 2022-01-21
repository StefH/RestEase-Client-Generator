using AnyOfTypes;
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

namespace RestEaseClientGenerator;

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

    public ICollection<AnyOf<RestEaseModel, RestEaseEnum, RestEaseInterface>> FromFileInternal(string path, GeneratorSettings settings, out OpenApiDiagnostic diagnostic, OpenApiSpecVersion openApiSpecVersion = OpenApiSpecVersion.OpenApi2_0)
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

    public ICollection<AnyOf<RestEaseModel, RestEaseEnum, RestEaseInterface>> FromDocumentInternal(OpenApiDocument document, GeneratorSettings settings, OpenApiSpecVersion openApiSpecVersion = OpenApiSpecVersion.OpenApi2_0, string? directory = null)
    {
        var schemaMapper = new SchemaMapper(settings);

        var @interface = new InterfaceMapper(settings, schemaMapper).Map(document, directory);

        var result = new List<AnyOf<RestEaseModel, RestEaseEnum, RestEaseInterface>>
        {
            @interface
        };

        if (document.Components?.Schemas != null)
        {
            foreach (var model in new ModelsMapper(@interface, settings, schemaMapper, OpenApiSpecVersion.OpenApi2_0, directory).Map(document.Components.Schemas))
            {
                if (model.IsFirst)
                {
                    result.Add(model.First);
                }
                if (model.IsSecond)
                {
                    result.Add(model.Second);
                }
            }
        }

        if (settings.GenerationType.HasFlag(GenerationType.Models))
        {
            // Add Inline Models
            foreach (var inlineModel in @interface.ExtraModels)
            {
                result.Add(inlineModel);
            }

            // Add Inline Enums
            foreach (var inlineEnum in schemaMapper.Enums)
            {
                result.Add(inlineEnum);
            }
        }

        return result;
    }

    public ICollection<GeneratedFile> FromDocument(OpenApiDocument document, GeneratorSettings settings, OpenApiSpecVersion openApiSpecVersion = OpenApiSpecVersion.OpenApi2_0, string? directory = null)
    {
        var result = FromDocumentInternal(document, settings, openApiSpecVersion, directory);

        var files = new List<GeneratedFile>();

        var @interface = result.Single(r => r.IsThird).Third;

        if (settings.GenerationType.HasFlag(GenerationType.Api))
        {
            var anyModels = result.Any(r => r.IsFirst);

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
            // Add Models
            var modelBuilder = new ModelBuilder(settings);
            var models = result.Where(r => r.IsFirst).Select(r => r.First);
            files.AddRange(models.Select(model => new GeneratedFile
            (
                FileType.Model,
                settings.ModelsNamespace,
                $"{model.ClassName}.cs",
                model.ClassName,
                modelBuilder.Build(model)
            )));

            var xxx = @interface.ExtraModels.FirstOrDefault(x => x.ClassName == "PrivateEndpointConnectionProperties");

            // Add Inline/External Models
            files.AddRange(@interface.ExtraModels.Select(model => new GeneratedFile
            (
                FileType.Model,
                settings.ModelsNamespace,
                $"{model.ClassName}.cs",
                model.ClassName,
                modelBuilder.Build(model)
            )));
            
            // Add Inline/External Enums
            var enumBuilder = new EnumBuilder(settings);
            var enums = result
                .Where(r => r.IsSecond)
                .Select(r => r.Second)
                .Where(e => e.Values is not null); // In case the values is null, do not create a file because enum is replaced by string
            files.AddRange(@enums.Select(@enum => new GeneratedFile
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
            return new[] { new GeneratedFile
            (
                FileType.ApiAndModels,
                string.Empty,
                $"{@interface.Name}.cs",
                @interface.Name,
                string.Join("\r\n", files.Select(f => f.Content))
            )};
        }

        //var schemaMapper = new SchemaMapper(settings);

        //var models = document.Components?.Schemas != null ?
        //    new ModelsMapper(settings, schemaMapper, openApiSpecVersion).Map(document.Components.Schemas).ToList() :
        //    new List<RestEaseModel>();

        //var @interface2 = new InterfaceMapper(settings, schemaMapper).Map(document, directory);

        

        //if (settings.GenerationType.HasFlag(GenerationType.Api))
        //{
        //    // Add Interface
        //    files.Add(new GeneratedFile
        //    (
        //        FileType.Api,
        //        settings.ApiNamespace,
        //        $"{@interface.Name}.cs",
        //        @interface.Name,
        //        new InterfaceBuilder(settings).Build(@interface, models.Any())
        //    ));

        //    var extensionContent = new ExtensionMethodsBuilder(settings).Build(@interface, @interface.Name);
        //    if (extensionContent != null)
        //    {
        //        var extensionClassName = $"{@interface.Name.Substring(1)}Extensions";

        //        // Add ApiExtension
        //        files.Add(new GeneratedFile
        //        (
        //            FileType.ApiExtensions,
        //            settings.ApiNamespace,
        //            $"{extensionClassName}.cs",
        //            extensionClassName,
        //            extensionContent
        //        ));
        //    }
        //}

        

        return files;
    }
}