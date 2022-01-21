using Microsoft.OpenApi.Models;
using RestEaseClientGenerator.Models.Internal;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;

namespace RestEaseClientGenerator.Mappers;

internal class ExternalModelMapper
{
    private readonly GeneratorSettings _settings;
    private readonly RestEaseInterface _interface;

    public ExternalModelMapper(GeneratorSettings settings, RestEaseInterface @interface)
    {
        _settings = settings;
        _interface = @interface;
    }

    public string Map(OpenApiSchema schema, string? directory)
    {
        if (directory is null)
        {
            throw new InvalidOperationException($"This schema contains an external reference ({schema.Reference.ExternalResource}) but no value for 'directory' is provided.");
        }

        var generator = new Generator();

        var settings = new GeneratorSettings
        {
            Namespace = _settings.Namespace,
            ApiName = _settings.ApiName,
            SingleFile = false,
            PreferredMultipleResponsesType = _settings.PreferredMultipleResponsesType,
            GenerationType = GenerationType.Models
        };

        var location = Path.Combine(directory, schema.Reference.ExternalResource.Replace("./", string.Empty));

        if (location.Contains("common.json"))
        {
            int yyy = 9;
        }

        var externalModels = generator.FromFileInternal(location, settings, out var x);

        var className = schema.Reference.Id.Split('/').Last();

        var externalModel = externalModels
            .Where(e => e.IsFirst)
            .Select(e => e.First)
            .FirstOrDefault(m => string.Equals(m.ClassName, className, StringComparison.OrdinalIgnoreCase));
        if (externalModel is not null)
        {
            if (_interface.ExtraModels.FirstOrDefault(m => m.ClassName == className) is null)
            {
                _interface.ExtraModels.Add(externalModel);
            }

            return externalModel.ClassName;
        }

        var externalEnum = externalModels
            .Where(e => e.IsSecond)
            .Select(e => e.Second)
            .FirstOrDefault(m => string.Equals(m.EnumName, className, StringComparison.OrdinalIgnoreCase));
        if (externalEnum is not null)
        {
            if (_interface.ExtraEnums.FirstOrDefault(m => m.EnumName == className) is null)
            {
                _interface.ExtraEnums.Add(externalEnum);
            }

            return externalEnum.EnumName;
        }

        throw new InvalidOperationException($"External model/enum with name '{className}' not found in {schema.Reference.ExternalResource}.");
    }
}