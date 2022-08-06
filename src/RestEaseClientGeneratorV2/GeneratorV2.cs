using System.Runtime;
using AnyOfTypes;
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

        var reader = new OpenApiStreamReader();
        var document = reader.Read(File.OpenRead(path), out diagnostic);

        var schemas = document.Components.Schemas.OrderBy(s => s.Key).ToList();

        var mapper = new SchemaMapper(settings);

        var models = new List<ModelDto>();
        var enums = new List<EnumDto>();
        foreach (var schema in schemas)
        {
            var propertyOrModelOrEnum = mapper.Map(schema.Key, string.Empty, schema.Value, models);
            switch (propertyOrModelOrEnum.CurrentType)
            {
                case AnyOfType.First:
                    if (propertyOrModelOrEnum.First.ArrayItemType != null)
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

                case AnyOfType.Second:
                    models.Add(propertyOrModelOrEnum.Second);
                    break;

                case AnyOfType.Third:
                    enums.Add(propertyOrModelOrEnum.Third);
                    break;
            }
        }

        var files = new List<GeneratedFile>();

        var modelBuilder = new ModelBuilder(settings, models);

        files.AddRange(models.Select(model => new GeneratedFile
        (
            FileType.Model,
            settings.ModelsNamespace,
            $"{model.ClassName}.cs",
            model.ClassName,
            modelBuilder.Build(model, model == models.First(), model == models.Last())
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
}