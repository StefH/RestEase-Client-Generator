using Microsoft.OpenApi.Models;
using RestEaseClientGenerator.Models.Internal;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;
using RestEaseClientGenerator.Utils;

namespace RestEaseClientGenerator.Mappers;

internal class ExternalReferenceMapper : BaseMapper
{
    private readonly GeneratorSettings _settings;
    private readonly RestEaseInterface _interface;

    public ExternalReferenceMapper(GeneratorSettings settings, RestEaseInterface @interface) : base(settings)
    {
        _settings = settings;
        _interface = @interface;
    }

    public OpenApiParameter? MapParameter(OpenApiReference reference, string? directory)
    {
        var result = CallFromFileInternal(reference, directory);
        var name = result.className;

        if (result.dto.Interface.Parameters.TryGetValue(name, out var parameter))
        {
            return parameter;
        }

        return null;
    }

    public PropertyDto MapProperty(OpenApiReference reference, string? directory)
    {
        var result = CallFromFileInternal(reference, directory);
        var className = result.className;

        foreach (var item in result.dto.Models)
        {
            if (_interface.ExtraModels.FirstOrDefault(m => string.Equals(m.ClassName, item.ClassName, StringComparison.InvariantCultureIgnoreCase)) is null)
            {
                _interface.ExtraModels.Add(item);
            }
        }

        foreach (var item in result.dto.Enums)
        {
            if (_interface.ExtraEnums.FirstOrDefault(m => string.Equals(m.EnumName, item.EnumName, StringComparison.InvariantCultureIgnoreCase)) is null)
            {
                _interface.ExtraEnums.Add(item);
            }
        }

        var foundModel = _interface.ExtraModels.FirstOrDefault(m => string.Equals(m.ClassName, className, StringComparison.InvariantCultureIgnoreCase));
        if (foundModel is not null)
        {
            return new PropertyDto(foundModel.ClassName, foundModel.ClassName);
        }

        if (_settings.PreferredEnumType == EnumType.Enum)
        {
            var foundEnum = _interface.ExtraEnums.FirstOrDefault(m => string.Equals(m.EnumName, className, StringComparison.InvariantCultureIgnoreCase));
            if (foundEnum is not null)
            {
                return new PropertyDto(foundEnum.EnumName, foundEnum.EnumName);
            }
        }
        else
        {
            // Probably an enum or just a simple parameter ?
            var nullable = "";
            return _settings.PreferredEnumType switch
            {
                //EnumType.Integer => new PropertyDto($"int{nullable}", className),
                //EnumType.Object => new PropertyDto($"object", className),
                _ => new PropertyDto($"string", className)
            };
        }

        throw new InvalidOperationException($"External model/enum with name '{className}' not found in local or external ({reference.ExternalResource}).");
    }

    private (string className, InternalDto dto) CallFromFileInternal(OpenApiReference reference, string? directory)
    {
        if (directory is null)
        {
            throw new InvalidOperationException($"This schema contains an external reference ({reference.ExternalResource}) but no value for 'directory' is provided.");
        }

        var generator = new Generator();

        var settings = TinyMapperUtils.Instance.Map<GeneratorSettings>(_settings);
        settings.GenerationType = GenerationType.Models;

        var location = Path.Combine(directory, reference.ExternalResource);

        var className = MakeValidReferenceId(reference.Id);

        return (className, generator.FromFileInternal(location, settings, out var x));
    }
}