using System.ComponentModel;
using RestEaseClientGenerator.Utils;

namespace RestEaseClientGenerator.Types;

[TypeConverter(typeof(EnumDescriptionConverter))]
[Flags]
public enum FileType
{
    [Description("Api")]
    Api = 1,

    [Description("ApiExtensions")]
    ApiExtensions = 2,

    [Description("Model")]
    Model = 3,

    [Description("Api and Models")]
    ApiAndModels = 4
}