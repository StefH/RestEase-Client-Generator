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
        var existingEnums = Enums.Where(e => string.Equals(e.Name, enumDto.Name, StringComparison.InvariantCultureIgnoreCase)).ToList();
        if (!existingEnums.Any())
        {
            Enums.Add(enumDto);
            return enumDto;
        }

        var existingEnumWithSameValues = existingEnums.SingleOrDefault(e => e.Values.SequenceEqual(enumDto.Values));
        if (existingEnumWithSameValues is null)
        {
            var newEnum = enumDto with
            {
                Name = $"{enumDto.Name}{existingEnums.Count}"
            };

            Enums.Add(newEnum);
            return newEnum;
        }

        return null;
    }
}