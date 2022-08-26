namespace RestEaseClientGenerator.Models.Internal;

internal record InternalDto
(
    List<ModelDto> Models,
    List<EnumDto> Enums
//IDictionary<string, OpenApiParameter> Parameters
)
{
    public void AddModel(ModelDto modelDto)
    {
        if (Models.FirstOrDefault(m => string.Equals(m.ClassName, modelDto.ClassName, StringComparison.InvariantCultureIgnoreCase)) is null)
        {
            Models.Add(modelDto);
        }
    }

    public EnumDto? AddEnum(EnumDto enumDto)
    {
        if (Enums.FirstOrDefault(m => string.Equals(m.Name, enumDto.Name, StringComparison.InvariantCultureIgnoreCase)) is null)
        {
            Enums.Add(enumDto);
            return enumDto;
        }

        var existingEnumWithSameValues = Enums.SingleOrDefault(existingEnum => existingEnum.Values.SequenceEqual(enumDto.Values));
        if (existingEnumWithSameValues is null)
        {
            var newEnum = enumDto with
            {
                Name = $"{enumDto.Name}{Enums.Count}"
            };

            Enums.Add(newEnum);
            return newEnum;
        }

        return null;
    }
}