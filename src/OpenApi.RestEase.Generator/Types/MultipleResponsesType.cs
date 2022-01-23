using System.ComponentModel;
using OpenApi.RestEase.Generator.Utils;

namespace OpenApi.RestEase.Generator.Types;

[TypeConverter(typeof(EnumDescriptionConverter))]
public enum MultipleResponsesType
{
    [Description("First")]
    First,

    [Description("Object")]
    Object,

    [Description("AnyOf<,>")]
    AnyOf
}