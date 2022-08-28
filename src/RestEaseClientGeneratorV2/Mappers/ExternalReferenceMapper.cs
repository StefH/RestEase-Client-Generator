using Microsoft.OpenApi.Models;
using RestEaseClientGenerator.Models.Internal;
using RestEaseClientGenerator.Settings;
using RestEaseClientGenerator.Types;
using RestEaseClientGenerator.Utils;
using RestEaseClientGeneratorV2;
using RestEaseClientGeneratorV2.Utils;

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

    public ReferenceDto MapReference(OpenApiReference reference, string path)
    {
        var (className, dto) = CallFromFileInternal(reference, path);

        if (className == "Display")
        {
            int yyy = 0;
        }

        foreach (var item in dto.Models)
        {
            _internalDto.AddModel(item);
        }

        foreach (var item in dto.Enums)
        {
            _internalDto.AddEnum(item, path);
        }

        var foundModel = _internalDto.Models.FirstOrDefault(m => string.Equals(m.ClassName, className, StringComparison.InvariantCultureIgnoreCase));
        if (foundModel is not null)
        {
            return new ReferenceDto(foundModel.ClassName, false, foundModel.Description);
        }

        var enumClassName = EnumHelper.GetEnumClassName(_settings, className, string.Empty);
        var foundEnum = _internalDto.Enums.FirstOrDefault(m => string.Equals(m.Name, enumClassName, StringComparison.InvariantCultureIgnoreCase));
        if (foundEnum is not null)
        {
            return _settings.PreferredEnumType == EnumType.Enum ?
                new ReferenceDto(foundEnum.Name, false, foundEnum.Description) :
                new ReferenceDto("string", false, foundEnum.Description);
        }

        //if (_settings.PreferredEnumType == EnumType.Enum)
        //{
        //    var foundEnum = _internalDto.Enums.FirstOrDefault(m => string.Equals(m.Name, className, StringComparison.InvariantCultureIgnoreCase));
        //    if (foundEnum is not null)
        //    {
        //        return new ReferenceDto(foundEnum.Name, false, foundEnum.Description);
        //    }
        //}
        //else
        //{
            
        //}

        throw new InvalidOperationException($"External model/enum with name '{className}' not found in external ({reference.ExternalResource}).");
    }

    private (string className, InternalDto internalDto) CallFromFileInternal(OpenApiReference reference, string path)
    {
        //if (path is null)
        //{
        //    throw new InvalidOperationException($"This schema contains an external reference ({reference.ExternalResource}) but no value for 'directory' is provided.");
        //}

        var generator = new GeneratorV2();

        var settings = TinyMapperUtils.Instance.Map<GeneratorSettings>(_settings);
        settings.GenerationType = GenerationType.Models;

        var location = Path.Combine(Path.GetDirectoryName(path)!, reference.ExternalResource);

        var className = MakeValidReferenceId(reference.Id);

        if (className == "ProxyResource")
        {
            int p = 6;
        }

        return (className, generator.MapInternal(settings, location, out _));
    }
}