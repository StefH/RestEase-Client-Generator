using Newtonsoft.Json;
using RestEaseClientGenerator.Extensions;

namespace RestEaseClientGenerator.Json;

/// <summary>
/// Based on https://stackoverflow.com/questions/59403305/deserializing-enum-from-descriptionattribute-using-custom-json-net-jsonconverter
/// </summary>
public class DescriptionEnumConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType.IsEnum;
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        var enumDescription = (string)reader.Value;

        return EnumExtensions.GetEnumByDescription(objectType, enumDescription);
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        if (value is Enum sourceEnum)
        {
            writer.WriteValue(sourceEnum.GetDescription());
        }
    }
}