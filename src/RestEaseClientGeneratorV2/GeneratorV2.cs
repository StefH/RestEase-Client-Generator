using Microsoft.OpenApi.Readers;
using RestEaseClientGenerator.Builders;
using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.Models.External;
using RestEaseClientGenerator.Models.Internal;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;
using RestEaseClientGenerator.Types.Internal;
using RestEaseClientGeneratorV2.Mappers;

namespace RestEaseClientGeneratorV2;

public class GeneratorV2
{
    public IReadOnlyList<GeneratedFile> Map(GeneratorSettings settings, string path, out OpenApiDiagnostic diagnostic)
    {
        string name = settings.ApiName.ToValidIdentifier(CasingType.Pascal);
        string interfaceName = $"I{name}Api";

        var internalDto = MapInternal(settings, path, out diagnostic);

        if (internalDto.Models.Any(m => m.ClassName == "Sku"))
        {
            int yyyy = 9;
        }

        var files = new List<GeneratedFile>();

        // Add Models
        var modelBuilder = new ModelBuilder(settings, internalDto.Models);
        if (internalDto.Models.Any())
        {
            var firstModel = internalDto.Models.First();
            var lastModel = internalDto.Models.Last();
            files.AddRange(internalDto.Models.Select(model => new GeneratedFile
            (
                FileType.Model,
                settings.ModelsNamespace,
                $"{model.ClassName}.cs",
                model.ClassName,
                modelBuilder.Build(model, model == firstModel, model == lastModel)
            )));
        }

        // Add Enums
        var enumBuilder = new EnumBuilder(settings);
        if (internalDto.Enums.Any())
        {
            var allEnums = internalDto.Enums
                .GroupBy(r => r.Name)
                .SelectMany(r => r)
                .OrderBy(r => r.Name)
                .ToList();
            var firstEnum = allEnums.First();
            var lastEnum = allEnums.Last();

            files.AddRange(allEnums.Select(@enum => new GeneratedFile
            (
                FileType.Model,
                settings.ModelsNamespace,
                $"{@enum.Name}.cs",
                @enum.Name,
                enumBuilder.Build(@enum, @enum == firstEnum, @enum == lastEnum)
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
                $"{interfaceName}.cs",
                interfaceName,
                string.Join("\r\n", content)
            )};
        }

        return files;
    }

    internal InternalDto MapInternal(GeneratorSettings settings, string path, out OpenApiDiagnostic diagnostic)
    {
        var directory = Path.GetDirectoryName(path);

        var dto = new InternalDto(new List<ModelDto>(), new List<EnumDto>());
        
        var mapper = new SchemaMapper(settings, dto);

        //var models = new List<ModelDto>(); 
       // var enums = new List<EnumDto>();

        var reader = new OpenApiStreamReader();
        var document = reader.Read(File.OpenRead(path), out diagnostic);
        var schemas = document.Components.Schemas.OrderBy(s => s.Key).ToList();
        foreach (var schema in schemas)
        {
            if (schema.Key == "ProxyResource")
            {
                int yyyy = 8;
            }

            var result = mapper.Map(schema.Key, string.Empty, schema.Value, false, directory);
            switch (result)
            {
                case PropertyDto propertyDto:
                    if (propertyDto.ArrayItemType != null)
                    {
                        // it's an array
                        int vvv = 9;
                    }
                    else
                    {
                        // it's an (string) enum
                        int aaa = 0;
                    }
                    break;

                case ModelDto modelDto:
                    dto.AddModel(modelDto);
                    break;

                case EnumDto enumDto:
                    dto.AddEnum(enumDto);
                    break;
            }
        }

        return dto;
    }
}