using Microsoft.OpenApi.Models;
using RestEaseClientGenerator.Models.Internal;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;
using RestEaseClientGenerator.Utils;

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

        var settings = TinyMapperUtils.Instance.Map<GeneratorSettings>(_settings);
        settings.GenerationType = GenerationType.Models;

        var location = Path.Combine(directory, schema.Reference.ExternalResource);

        var externalModelOrEnum = generator.FromFileInternal(location, settings, out var x);

        var className = schema.Reference.Id.Split('/').Last();

        foreach (var externalModel in externalModelOrEnum)
        {
            if (externalModel.IsFirst)
            {
                if (_interface.ExtraModels.FirstOrDefault(m => string.Equals(m.ClassName, externalModel.First.ClassName, StringComparison.InvariantCultureIgnoreCase)) is null)
                {
                    _interface.ExtraModels.Add(externalModel);
                }
            }

            if (externalModel.IsSecond)
            {
                if (_interface.ExtraEnums.FirstOrDefault(m => string.Equals(m.EnumName, externalModel.Second.EnumName, StringComparison.InvariantCultureIgnoreCase)) is null)
                {
                    _interface.ExtraEnums.Add(externalModel);
                }
            }
        }

        var foundModel = _interface.ExtraModels.FirstOrDefault(m => string.Equals(m.ClassName, className, StringComparison.InvariantCultureIgnoreCase));
        if (foundModel is not null)
        {
            return foundModel.ClassName;
        }

        if (_settings.PreferredEnumType == EnumType.Enum)
        {
            var foundEnum = _interface.ExtraEnums.FirstOrDefault(m => string.Equals(m.EnumName, className, StringComparison.InvariantCultureIgnoreCase));
            if (foundEnum is not null)
            {
                return foundEnum.EnumName;
            }
        }
        else
        {
            var nullable = schema.Nullable ? "?" : string.Empty;
            return _settings.PreferredEnumType switch
            {
                EnumType.Integer => $"int{nullable}",
                EnumType.Object => $"object{nullable}",
                _ => $"string{nullable}"
            };
        }

        throw new InvalidOperationException($"External model/enum with name '{className}' not found in local or external ({schema.Reference.ExternalResource}).");
    }
}