using System.ComponentModel;
using RestEaseClientGenerator.Utils;

namespace RestEaseClientGenerator.Types;

[TypeConverter(typeof(EnumDescriptionConverter))]
[Flags]
public enum GenerationType
{
    [Description("Api")]
    Api = 0b00000001,

    [Description("Models")]
    Models = 0b00000010,

    [Description("Api and Models")]
    Both = Api | Models
}