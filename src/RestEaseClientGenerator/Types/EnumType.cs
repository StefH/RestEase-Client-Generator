// ReSharper disable All
using RestEaseClientGenerator.Utils;
using System.ComponentModel;

namespace RestEaseClientGenerator.Types
{
    [TypeConverter(typeof(EnumDescriptionConverter))]
    public enum EnumType
    {
        [Description("string")]
        String,

        [Description("object")]
        Object,

        [Description("integer")]
        Integer,

        [Description("enum")]
        Enum
    }
}