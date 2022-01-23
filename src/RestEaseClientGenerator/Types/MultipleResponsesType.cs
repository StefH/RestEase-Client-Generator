using System.ComponentModel;
using RestEaseClientGenerator.Utils;

namespace RestEaseClientGenerator.Types;

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