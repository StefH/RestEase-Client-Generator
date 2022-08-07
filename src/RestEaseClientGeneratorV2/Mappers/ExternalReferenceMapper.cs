using Microsoft.OpenApi.Models;
using RestEaseClientGenerator.Models.Internal;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;
using RestEaseClientGenerator.Utils;
using RestEaseClientGeneratorV2;

namespace RestEaseClientGenerator.Mappers;

internal class ExternalReferenceMapper : BaseMapper
{
    private readonly GeneratorSettings _settings;
    private readonly InternalDto _internalDto;

    public ExternalReferenceMapper(GeneratorSettings settings, InternalDto internalDto) : base(settings)
    {
        _settings = settings;
        _internalDto = internalDto;
    }

    //public OpenApiParameter? MapParameter(OpenApiReference reference, string? directory)
    //{
    //    var (className, dto) = CallFromFileInternal(reference, directory);

    //    if (dto.Interface.OpenApiDocument.Components.Parameters.TryGetValue(className, out var parameter))
    //    {
    //        return parameter;
    //    }

    //    return null;
    //}

    public ReferenceDto MapReference(OpenApiReference reference, string? directory)
    {
        var (className, dto) = CallFromFileInternal(reference, directory);

        foreach (var item in dto.Models)
        {
            if (_internalDto.Models.FirstOrDefault(m => string.Equals(m.ClassName, item.ClassName, StringComparison.InvariantCultureIgnoreCase)) is null)
            {
                _internalDto.Models.Add(item);
            }
        }

        foreach (var item in dto.Enums)
        {
            if (_internalDto.Enums.FirstOrDefault(m => string.Equals(m.Name, item.Name, StringComparison.InvariantCultureIgnoreCase)) is null)
            {
                _internalDto.Enums.Add(item);
            }
        }

        var foundModel = _internalDto.Models.FirstOrDefault(m => string.Equals(m.ClassName, className, StringComparison.InvariantCultureIgnoreCase));
        if (foundModel is not null)
        {
            return new ReferenceDto(foundModel.ClassName, false, foundModel.Description);
        }

        if (_settings.PreferredEnumType == EnumType.Enum)
        {
            var foundEnum = _internalDto.Enums.FirstOrDefault(m => string.Equals(m.Name, className, StringComparison.InvariantCultureIgnoreCase));
            if (foundEnum is not null)
            {
                return new ReferenceDto(foundEnum.Name, false, foundEnum.Description);
            }
        }
        else
        {
            return new ReferenceDto("string", false, null);
        }

        throw new InvalidOperationException($"External model/enum with name '{className}' not found in external ({reference.ExternalResource}).");
    }

    private (string className, InternalDto internalDto) CallFromFileInternal(OpenApiReference reference, string? directory)
    {
        if (directory is null)
        {
            throw new InvalidOperationException($"This schema contains an external reference ({reference.ExternalResource}) but no value for 'directory' is provided.");
        }

        var generator = new GeneratorV2();

        var settings = TinyMapperUtils.Instance.Map<GeneratorSettings>(_settings);
        settings.GenerationType = GenerationType.Models;

        var location = Path.Combine(directory, reference.ExternalResource);

        var className = MakeValidReferenceId(reference.Id);

        return (className, generator.MapInternal(settings, location, out _));
    }
}