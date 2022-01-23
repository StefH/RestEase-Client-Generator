using System.ComponentModel;
using System.Globalization;
using OpenApi.RestEase.Generator.Extensions;

namespace OpenApi.RestEase.Generator.Utils;

/// <summary>
/// EnumConverter supporting System.ComponentModel.DescriptionAttribute
/// Based on https://www.codeproject.com/articles/6294/description-enum-typeconverter
/// </summary>
public class EnumDescriptionConverter : EnumConverter
{
    private readonly Type _enumType;

    public EnumDescriptionConverter(Type type) : base(type)
    {
        _enumType = type;
    }

    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
        if (value is Enum @enum && destinationType == typeof(string))
        {
            return @enum.GetDescription();
        }

        if (value is string @string && destinationType == typeof(string))
        {
            return EnumExtensions.GetDescription(_enumType, @string);
        }

        return base.ConvertTo(context, culture, value, destinationType);
    }

    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
        if (value is string @string)
        {
            return EnumExtensions.GetEnumByDescription(_enumType, @string);
        }

        if (value is Enum @enum)
        {
            return @enum.GetDescription();
        }

        return base.ConvertFrom(context, culture, value);
    }
}