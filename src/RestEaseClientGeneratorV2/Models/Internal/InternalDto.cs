using Microsoft.OpenApi.Models;

namespace RestEaseClientGenerator.Models.Internal;

internal record InternalDto
(
    OpenApiDocument OpenApiDocument,
    List<ModelDto> Models,
    List<EnumDto> Enums
//IDictionary<string, OpenApiParameter> Parameters
)
{
    public void AddModel(ModelDto modelDto)
    {
        if (Models.FirstOrDefault(m => string.Equals(m.Name, modelDto.Name, StringComparison.InvariantCultureIgnoreCase)) is null)
        {
            Models.Add(modelDto);
        }
    }

    public EnumDto? AddEnum(EnumDto enumDto, string path, int? count = null)
    {
        var existingEnums = Enums.Where(e => string.Equals(e.Name, enumDto.Name, StringComparison.InvariantCultureIgnoreCase)).ToList();
        if (!existingEnums.Any())
        {
            Enums.Add(enumDto);
            return enumDto;
        }

        var existingEnumWithSameValues = existingEnums.SingleOrDefault(e => e.Values.SequenceEqual(enumDto.Values));
        if (existingEnumWithSameValues is null)
        {
            var prefix = Path.GetFileNameWithoutExtension(path);
            var newEnum = enumDto with
            {
                Name = $"{prefix}{enumDto.Name}"
            };

            var existingEnumsWithNewName = Enums.Where(e => string.Equals(e.Name, newEnum.Name, StringComparison.InvariantCultureIgnoreCase)).ToList();
            if (!existingEnumsWithNewName.Any())
            {
                Enums.Add(enumDto);
                return enumDto;
            }

            var newEnumWithCount = enumDto with
            {
                Name = $"{newEnum.Name}{existingEnums.Count}"
            };
            
            Enums.Add(newEnumWithCount);
            return newEnumWithCount;
        }

        return null;
    }
}