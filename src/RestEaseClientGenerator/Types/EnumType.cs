// ReSharper disable All

using System.ComponentModel;
using RestEaseClientGenerator.Utils;

namespace RestEaseClientGenerator.Types;

[TypeConverter(typeof(EnumDescriptionConverter))]
public enum EnumType
{
    [Description("string")]
    String,

    //[Description("object")]
    //Object,

    //[Description("integer")]
    //Integer,

    [Description("enum")]
    Enum
}