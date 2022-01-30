using Newtonsoft.Json;
using RestEaseClientGenerator.Extensions;

namespace RestEaseClientGenerator.Json;

/// <summary>
/// Based on https://stackoverflow.com/questions/59403305/deserializing-enum-from-descriptionattribute-using-custom-json-net-jsonconverter
/// </summary>
/// <typeparam name="T">Generic Type</typeparam>
public class DescriptionEnumConverter<T> : JsonConverter where T : struct, IComparable, IConvertible, IFormattable
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(T);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        var type = typeof(T);

        if (!type.IsEnum) throw new InvalidOperationException();

        var enumDescription = (string)reader.Value;

        return EnumExtensions.GetEnumByDescription(typeof(T), enumDescription);
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        var type = typeof(T);

        if (!type.IsEnum) throw new InvalidOperationException();

        if (value is Enum sourceEnum)
        {
            writer.WriteValue(sourceEnum.GetDescription());
        }
    }
}