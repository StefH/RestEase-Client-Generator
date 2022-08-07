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

        var modelBuilder = new ModelBuilder(settings, internalDto.Models);

        var files = new List<GeneratedFile>();
        files.AddRange(internalDto.Models.Select(model => new GeneratedFile
        (
            FileType.Model,
            settings.ModelsNamespace,
            $"{model.ClassName}.cs",
            model.ClassName,
            modelBuilder.Build(model, model == internalDto.Models.First(), model == internalDto.Models.Last())
        )));

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

        var reader = new OpenApiStreamReader();
        var document = reader.Read(File.OpenRead(path), out diagnostic);

        var schemas = document.Components.Schemas.OrderBy(s => s.Key).ToList();

        var mapper = new SchemaMapper(settings);

        var models = new List<ModelDto>(); 
        var enums = new List<EnumDto>();
        foreach (var schema in schemas)
        {
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
                    models.Add(modelDto);
                    break;

                case EnumDto enumDto:
                    enums.Add(enumDto);
                    break;
            }
        }

        return new InternalDto(models, enums);
    }
}