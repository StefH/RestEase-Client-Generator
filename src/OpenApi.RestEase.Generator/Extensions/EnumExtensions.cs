using System.ComponentModel;
using System.Reflection;
using RestEaseClientGenerator.Utils;

namespace RestEaseClientGenerator.Extensions;

public static class EnumExtensions
{
    /// <summary>
    /// Gets Enum Value's Description Attribute
    /// </summary>
    /// <param name="value">The type you want the description attribute for</param>
    /// <returns>The description, if any, else it's .ToString()</returns>
    public static string GetDescription(this Enum value)
    {
        var fieldInfo = value.GetType().GetField(value.ToString());
        var attribute = fieldInfo.GetCustomAttribute<DescriptionAttribute>(false);

        return attribute != null ? attribute.Description : value.ToString();
    }

    /// <summary>
    /// Gets the description for certain named type in an Enumeration
    /// </summary>
    /// <param name="type">The type of the Enumeration</param>
    /// <param name="name">The name of the Enumeration type</param>
    /// <returns>The description, if any, else the passed name</returns>
    public static string GetDescription(Type type, string name)
    {
        var fieldInfo = TypeHelper.GetNonNullableType(type).GetField(name);
        var attribute = fieldInfo.GetCustomAttribute<DescriptionAttribute>(false);

        return attribute != null ? attribute.Description : name;
    }

    /// <summary>
    /// Gets the type of an Enum, based on it's Description Attribute or named type
    /// </summary>
    /// <param name="type">The Enum type</param>
    /// <param name="description">The description or name of the element</param>
    /// <returns>The type, or the passed in description, if it was not found</returns>
    public static object GetEnumByDescription(Type type, string description)
    {
        foreach (var fieldInfo in TypeHelper.GetNonNullableType(type).GetFields())
        {
            var attribute = fieldInfo.GetCustomAttribute<DescriptionAttribute>(false);
            if (attribute != null)
            {
                if (attribute.Description == description)
                {
                    return fieldInfo.GetValue(fieldInfo.Name);
                }
            }

            if (fieldInfo.Name == description)
            {
                return fieldInfo.GetValue(fieldInfo.Name);
            }
        }

        return description;
    }
}