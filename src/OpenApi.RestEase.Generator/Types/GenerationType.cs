using System.ComponentModel;
using OpenApi.RestEase.Generator.Utils;

namespace OpenApi.RestEase.Generator.Types;

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