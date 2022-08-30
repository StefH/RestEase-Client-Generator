using Microsoft.OpenApi.Readers;
using RestEaseClientGenerator.Builders;
using RestEaseClientGenerator.Extensions;
using RestEaseClientGenerator.Mappers;
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
        //string interfaceName = $"I{name}Api";

        var (internalDto, restEaseInterface) = MapInternal(settings, path, out diagnostic);

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
                $"{model.Name}.cs",
                model.Name,
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

        var anyModels = internalDto.Models.Any() || internalDto.Enums.Any();

        // Add Interface
        files.Add(new GeneratedFile
        (
            FileType.Api,
            settings.ApiNamespace,
            $"{restEaseInterface.Name}.cs",
            restEaseInterface.Name,
            new InterfaceBuilder(settings).Build(restEaseInterface, anyModels)
        ));

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
                $"{restEaseInterface}.cs",
                restEaseInterface.Name,
                string.Join("\r\n", content)
            )};
        }

        return files;
    }

    internal (InternalDto InternalDto, RestEaseInterface Interface) MapInternal(GeneratorSettings settings, string path, out OpenApiDiagnostic diagnostic)
    {
        var reader = new OpenApiStreamReader();
        var document = reader.Read(File.OpenRead(path), out diagnostic);

        var dto = new InternalDto(document, new List<ModelDto>(), new List<EnumDto>());
        
        var mapper = new SchemaMapper(settings, dto);
        
        var schemas = document.Components.Schemas.OrderBy(s => s.Key).ToList();
        foreach (var schema in schemas)
        {
            var result = mapper.Map(schema.Key, string.Empty, schema.Value, false, path);
            switch (result)
            {
                case PropertyDto propertyDto:
                    if (propertyDto.ArrayItemType != null)
                    {
                        // it's an array
                        throw new ApplicationException();
                        int vvv = 9;
                    }
                    else
                    {
                        // it's an (string) enum
                        int aaa = 0;
                        throw new ApplicationException();
                    }
                    break;

                case ModelDto modelDto:
                    dto.AddModel(modelDto);
                    break;

                case EnumDto enumDto:
                    dto.AddEnum(enumDto, path);
                    break;
            }
        }


        var @interface = new InterfaceMapper(settings, mapper).Map(document, dto, path);

        return (dto, @interface);
    }
}