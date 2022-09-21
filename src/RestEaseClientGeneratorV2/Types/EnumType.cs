using System.ComponentModel;
using RestEaseClientGenerator.Utils;

namespace RestEaseClientGenerator.Types;

[TypeConverter(typeof(EnumDescriptionConverter))]
public enum EnumType
{
    [Description("ItemType")]
    ItemType,

    [Description("Enum")]
    Enum
}